using Entity.Model;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entity.Model.Enums;

namespace WpfProjZespClient
{
    public class OxyPlotModel : INotifyPropertyChanged
    {
        private OxyPlot.PlotModel plotModel;
        public OxyPlot.PlotModel PlotModel
        {
            get
            {
                return plotModel;
            }
            set
            {
                plotModel = value; OnPropertyChanged("PlotModel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private readonly List<OxyPlot.OxyColor> chartColors = new List<OxyPlot.OxyColor>
        {
            OxyPlot.OxyColors.Green,
            OxyPlot.OxyColors.Blue
        };

        internal void Setup()
        {
            this.PlotModel = new OxyPlot.PlotModel();
        }

        internal void Draw(Statistics statistics, SubstancesType substancesType)
        {
            Setup();
            plotModel.Series = new System.Collections.ObjectModel.Collection<OxyPlot.Series.Series> { };
            plotModel.Axes = new System.Collections.ObjectModel.Collection<OxyPlot.Axes.Axis> { };

            if (statistics.DayFoods.Count <= 0)
            {
                return;
            }

            List<double> X = new List<double>();
            List<double> Y = new List<double>();
            List<double> Xnorm = new List<double>();
            List<double> Ynorm = new List<double>();
            Ynorm.Add(0);
            Ynorm.Add(0);

            int index = 1;
            foreach (DayFood dayFood in statistics.DayFoods)
            {
                X.Add(index++);
                if (dayFood.MealNutritionalVal.Count == 0)
                {
                    Y.Add(0);
                    continue;
                }
                Y.Add(0);
                foreach (MealNutritionalValues m in dayFood.MealNutritionalVal)
                {
                    switch (substancesType)
                    {
                        case SubstancesType.Kalorie:
                            Ynorm[0] = statistics.PropperDayValues.Calories;
                            Y[Y.Count-1] += m.Calories;
                            break;
                        case SubstancesType.Tluszcze:
                            Ynorm[0] = statistics.PropperDayValues.Fats;
                            Y[Y.Count - 1] += m.Fats;
                            break;
                        case SubstancesType.Weglowodany:
                            Ynorm[0] = statistics.PropperDayValues.Carbohydrates;
                            Y[Y.Count - 1] += m.Carbohydrates;
                            break;
                        case SubstancesType.Bialka:
                            Ynorm[0] = statistics.PropperDayValues.Proteins;
                            Y[Y.Count - 1] += m.Proteins;
                            break;
                    }
                }
            }
            Ynorm[1] = Ynorm[0];
            Xnorm.Add(X.First());
            Xnorm.Add(X.Last());

            AddSeries(OxyPlot.MarkerType.Circle, chartColors[1], "Użytkownik", X, Y);
            AddSeries(OxyPlot.MarkerType.None, chartColors[0], "Norma", Xnorm, Ynorm);
        }

        internal void AddSeries(OxyPlot.MarkerType showType, OxyPlot.OxyColor color, string title, List<double> X, List<double> Y)
        {
            OxyPlot.Series.LineSeries seriesPoints = new OxyPlot.Series.LineSeries
            {
                MarkerType = showType,
                MarkerSize = 9,
                MarkerStroke = chartColors[1],
                Title = title
            };

            for (int n = 0; n < X.Count; n++)
                seriesPoints.Points.Add(new OxyPlot.DataPoint(X[n], Y[n]));

            plotModel.Series.Add(seriesPoints);
        }
    }
}
