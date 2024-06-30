using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using Reactive.Bindings;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Details.Interfaces;

namespace Details.ViewModels
{
    public class ViewAViewModel : BindableBase, IImageViewer
    {
        private VideoCapture _capture;
        private Mat _frame;
        private BitmapSource _bitmap;
        private bool _isCapturing;
        private CancellationTokenSource _cancellationTokenSource;

        public ReactiveProperty<BitmapSource> ImageSrc { get; set; }

        public ViewAViewModel()
        {
            ImageSrc = new ReactiveProperty<BitmapSource>();

            InitializeCamera();
        }

        private void InitializeCamera()
        {
            _capture = new VideoCapture(0);
            if (!_capture.IsOpened())
            {
                MessageBox.Show("No camera found.");
                return;
            }

            _frame = new Mat();
            _isCapturing = true;
            _cancellationTokenSource = new CancellationTokenSource();

            Task.Run(() => CaptureCamera(_cancellationTokenSource.Token));
        }

        private void CaptureCamera(CancellationToken token)
        {
            while (_isCapturing && !token.IsCancellationRequested)
            {
                _capture.Read(_frame);
                if (!_frame.Empty())
                {
                    _bitmap = _frame.ToBitmapSource();
                    _bitmap.Freeze();
                    ImageSrc.Value = _bitmap;
                    //Dispatcher.BeginInvoke(new Action(() =>
                    //{
                    //    ImageSrc.Value = _bitmap;
                    //}));
                }
            }
        }

        private void CaptureButton_Click(object sender, RoutedEventArgs e)
        {
            if (_bitmap != null)
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(_bitmap));

                using (var stream = new FileStream("capture.png", FileMode.Create))
                {
                    encoder.Save(stream);
                }

                MessageBox.Show("Photo saved to capture.png");
            }
        }

        void IImageViewer.NotifyFrame(BitmapSource source)
        {
            source.Freeze();
            ImageSrc.Value = source;
        }

        //protected override void OnClosed(EventArgs e)
        //{
        //    base.OnClosed(e);
        //    _isCapturing = false;
        //    _cancellationTokenSource.Cancel();
        //    _capture.Release();
        //}
    }
}
