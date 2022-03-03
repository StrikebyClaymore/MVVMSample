using MVVMSample.Views.Windows.Infrastructure.Commands;
using MVVMSample.Views.Windows.ViewModels.Base;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using System.Collections.ObjectModel;
using MVVMSample.Models.Decanat;
using System.Linq;

namespace MVVMSample.Views.Windows.ViewModels
{   
    internal class MainWindowViewModel : WindowBase
    {
        public ObservableCollection<Group> Groups { get; }

        #region Commands

        #region Close Applicataion Command

        public ICommand CloseApplicationCommand { get; set; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            Title = "Main window";

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            var student_index = 1;
            var students = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"Name {student_index}",
                Surname = $"Surname {student_index}",
                Patronymic = $"Patronymic {student_index}",
                Birthday = DateTime.Now,
                Rating = 0,
            });
            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>()
            });
            Groups = new ObservableCollection<Group>(groups);

            CreatePlotModel();


        }

        #region Test Plot Model

        private IEnumerable<Models.DataPoint> _Points;
        public IEnumerable<Models.DataPoint> Points
        {
            get => _Points;
            set => Set(ref _Points, value);
        }
        public PlotModel MyModel { get; private set; }

        private void CreatePlotModel()
        {
            var list = new List<Models.DataPoint>();

            var dataPoints = new LineSeries();
            dataPoints.DataFieldX = "X";
            dataPoints.DataFieldY = "Y";

            for (double x = 0; x < 360; x += 0.1)
            {
                const double toRad = Math.PI / 180;
                var y = Math.Sin(2 * Math.PI * x * toRad);

                //dataPoints.Points.Add(new DataPoint (x, y));
                list.Add(new Models.DataPoint { X = x, Y = y });
            }

            Points = list;

            dataPoints.ItemsSource = Points;

            var model = new PlotModel { Title = "LineSeries with default style" };
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
            var lineSeries1 = dataPoints;
            lineSeries1.Title = "LineSeries 1";
            model.Series.Add(lineSeries1);
            MyModel = model;

            /*this.MyModel = new PlotModel { Title = "Example 1" };
            this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 360, "cos(x)"));*/
        }

        #endregion
    }
}
