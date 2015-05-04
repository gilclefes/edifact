using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EdifactViewer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			_model = new MainModel();
			DataContext = _model;
		}

		private readonly MainModel _model;
		public MainModel Model { get { return _model; } }

		private void LoadEdifact(System.IO.FileInfo fi)
		{
			Model.Segments.Clear();

			if (!fi.Exists)
				return;

			var result = Edifact.EdifactReader.ReadFile(fi);

			// A edi file must contains of at least 4 lines (Self maid rule)
			if (result.Segments.Count < 4)
				return;

			int segmentNumber = 0;
			int leftPadding = 0;
			bool firstLin = true;
			foreach (var segment in result.Segments)
			{
				switch (segment.Tag)
				{
					case "LIN":
						if (!firstLin)
							leftPadding--;
						firstLin = false;
						break;
				}

				var sgmnt = new SegmentWrapper(++segmentNumber, segment) { SegmentMargin = new Thickness(leftPadding * 20, 0, 0, 0) };

				switch (segment.Tag)
				{
					case "LIN":
					case "UNH":
					case "BGM":
						leftPadding++;
						break;
					case "UNS":
					case "UNT":
					case "CNT":
						leftPadding--;
						break;
				}

				Model.Segments.Add(sgmnt);
			}
		}

		public class MainModel
		{
			public MainModel()
			{
				Segments = new ObservableCollection<SegmentWrapper>();
			}
			public ObservableCollection<SegmentWrapper> Segments { get; set; }
		}

		public class SegmentWrapper
		{
			private readonly int _segmentNumber;
			private readonly Edifact.Segment _segment;
			public SegmentWrapper(int segmentNumber, Edifact.Segment segment)
			{
				_segmentNumber = segmentNumber;
				_segment = segment;
				SegmentMargin = new Thickness(0);
			}
			public int SegmentNumber { get { return _segmentNumber; } }
			public Edifact.Segment Segment { get { return _segment; } }
			public string SegmentText { get { return _segment.ToString(); } }
			public string SegmentDescription { get { return Segment.Description; } }

			public Thickness SegmentMargin { get; set; }
		}

		private void ListView_DragEnter(object sender, DragEventArgs e)
		{
			e.Effects = DragDropEffects.Copy;
			//if (e.Data.GetDataPresent(DataFormats.StringFormat))
			//{
			//	string dataString = (string)e.Data.GetData(DataFormats.StringFormat);
			//}
		}
		private void ListView_Drop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				var files = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (!files.Any())
					return;

				try
				{
					LoadEdifact(new FileInfo(files[0]));
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}

			}
		}
	}
}
