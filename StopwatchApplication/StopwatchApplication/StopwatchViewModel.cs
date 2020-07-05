#region

using System;
using System.Diagnostics;
using System.Windows.Media;
using Reactive.Bindings;

#endregion

namespace StopwatchApplication
{
    public class StopwatchViewModel
    {
        /// <summary>
        /// 時間計測オブジェクト
        /// </summary>
        private readonly Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// <see cref="StopwatchViewModel"/>のコンストラクタです。
        /// </summary>
        public StopwatchViewModel()
        {
            ActCommand = new ReactiveCommand();
            ActCommand.Subscribe(_ => ExecuteAction());
            SetButtonName();
            BackgroundColor.Value = new SolidColorBrush(Colors.Transparent);
        }

        /// <summary>
        /// 時間
        /// </summary>
        public ReactiveProperty<string> TimeText { get; } = new ReactiveProperty<string>();

        /// <summary>
        /// 評価
        /// </summary>
        public ReactiveProperty<string> ReviewText { get; } = new ReactiveProperty<string>();

        /// <summary>
        /// ボタン名
        /// </summary>
        public ReactiveProperty<string> ButtonName { get; } = new ReactiveProperty<string>();

        /// <summary>
        /// ボタン処理
        /// </summary>
        public ReactiveCommand ActCommand { get; }

        /// <summary>
        /// 評価
        /// </summary>
        public ReactiveProperty<SolidColorBrush> BackgroundColor { get; } = new ReactiveProperty<SolidColorBrush>();

        /// <summary>
        /// ボタン名を設定
        /// </summary>
        private void SetButtonName()
        {
            ButtonName.Value = _stopwatch.IsRunning ? "Stop" : "Start";
        }

        /// <summary>
        /// ボタン処理を実行します。
        /// </summary>
        private void ExecuteAction()
        {
            if (_stopwatch.IsRunning)
            {
                _stopwatch.Stop();
                TimeText.Value = _stopwatch.Elapsed.TotalSeconds + "s";
                if (_stopwatch.Elapsed.TotalSeconds >= 10d)
                {
                    ReviewText.Value = "Over...";
                    BackgroundColor.Value = new SolidColorBrush(Colors.DeepPink);
                }
                else if (_stopwatch.Elapsed.TotalSeconds >= 9.75d)
                {
                    ReviewText.Value = "Great!!!";
                    BackgroundColor.Value = new SolidColorBrush(Colors.DeepSkyBlue);
                }
                else if (_stopwatch.Elapsed.TotalSeconds >= 9.5d)
                {
                    ReviewText.Value = "Nice!";
                    BackgroundColor.Value = new SolidColorBrush(Colors.YellowGreen);
                }
                else if (_stopwatch.Elapsed.TotalSeconds >= 9.0d)
                {
                    ReviewText.Value = "Good!";
                    BackgroundColor.Value = new SolidColorBrush(Colors.DarkOrange);
                }
                else
                {
                    ReviewText.Value = "Bad...";
                    BackgroundColor.Value = new SolidColorBrush(Colors.Yellow);
                }
            }
            else
            {
                TimeText.Value = "Purpose:10s";
                ReviewText.Value = "Starting...";
                BackgroundColor.Value = new SolidColorBrush(Colors.Transparent);
                _stopwatch.Reset();
                _stopwatch.Start();
            }
        }
    }
}