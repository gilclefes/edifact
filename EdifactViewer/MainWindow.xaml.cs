using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using Edifact;

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

		private void LoadEdifact(FileInfo fi)
		{
			Model.Segments.Clear();

			if (!fi.Exists)
				return;

			var result = EdifactReader.ReadFile(fi, Encoding.Default);

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
					case "UNS":
					case "UNT":
					case "UNZ":
						leftPadding--;
						break;
					case "LIN":
						if (!firstLin)
							leftPadding--;
						firstLin = false;
						break;
				}

				var sgmnt = new SegmentWrapper(++segmentNumber, segment, result.Settings) { SegmentMargin = new Thickness(leftPadding * 20, 0, 0, 0) };

				switch (segment.Tag)
				{
					case "UNB":
					case "UNH":
					case "LIN":
						leftPadding++;
						break;
				}

				switch (segment.Tag)
				{
					case "LIN":
					case "UNS":
						sgmnt.SegmentBorder = new Thickness(0, 1, 0, 0);
						break;
					default:
						sgmnt.SegmentBorder = new Thickness(0, 0, 0, 0);
						break;
				}

				Model.Segments.Add(sgmnt);
			}
		}

		private void ListView_Drop(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent(DataFormats.FileDrop))
				return;

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
		private readonly Segment _segment;
		private readonly ISettings _settings;
		public SegmentWrapper(int segmentNumber, Segment segment, ISettings settings)
		{
			_segmentNumber = segmentNumber;
			_segment = segment;
			_settings = settings;
			SegmentMargin = new Thickness(0);
		}
		public int SegmentNumber { get { return _segmentNumber; } }
		public Segment Segment { get { return _segment; } }
		public ISettings Settings { get { return _settings; } }
		public string SegmentText { get { return _segment.ToString() + _settings.SegmentTerminator; } }
		public string SegmentDescription { get { return Segment.Description; } }

		public Thickness SegmentBorder { get; set; }
		public Thickness SegmentMargin { get; set; }
	}

}
