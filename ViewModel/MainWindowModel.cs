using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace ViewModel
{
    [Serializable()]
    public class MainWindowModel : INotifyPropertyChanged
    {
        public Dictionary<string, double> DistanceCollections 
        { 
            get => new Dictionary<string, double>
            {
                {"мм",1},
                {"см",10},
                {"дм",100},
                {"м",1000},
                {"км",1000000 }
            };
        } 
        public Dictionary<string, double> TimeCollections
        {
            get => new Dictionary<string, double>
            {
                {"нс", 0.000001},
                {"мкс", 0.001},
                {"мс",1},
                {"с",1000},
                {"мин",60000},
                {"ч",3600000}
            };
        } 
        public Dictionary<string, double> TempCollections
        {
            get => new Dictionary<string, double>
            {
                {"°C",273.15},
                {"K",0}
            };
        } 
        public Dictionary<string, double> MeasureOfАngle
        {
            get => new Dictionary<string, double>
            {
                {"°",180/Math.PI },
                {"рад",1}
            };
        } 
        public BusinessLogic BL { get; set; } = new BusinessLogic();

        //DistanceEnumColumnParse WavelengthDistanceParse = new DistanceEnumColumnParse();

        public MainWindowModel()
        {

        }
        private double _speedLight;
        private double _speedLightDistance;
        private double _speedLightTime;

        private double _wavelength;
        private double _wavelengthDistance;

        private double _flightAltitude;
        private double flightAltitudeDistance;

        private double _flightSpeed;
        private double _flightSpeedDistance;
        private double _flightSpeedTime;

        private double _swath;
        private double _swathDistance;

        private double _radarResolution;
        private double _radarResolutionDistance;

        private double _maxRangeOfRadarSurveillance;
        private double _maxRangeOfRadarSurveillanceDistance;

        private double _openingTheAntennasInTheHorizontal;
        private double _openingTheAntennasInTheHorizontalDistance;

        //Скорость света (м/с)
        public double SpeedLight
        {
            get => _speedLight * (1000 / SpeedLightDistance) * (SpeedLightTime / 1000);
            set => _speedLight = value * (SpeedLightDistance / 1000) * (1000 / SpeedLightTime);
        }
        public double SpeedLightDistance
        {
            get => _speedLightDistance;
            set { _speedLightDistance = value; OnPropertyChanged("SpeedLight"); }
        }
        public double SpeedLightTime
        {
            get => _speedLightTime;
            set { _speedLightTime = value; OnPropertyChanged("SpeedLight"); }
        }

        //Длина рабочей волны (м)
        public double Wavelength
        {
            get => _wavelength * (1000 / WavelengthDistance);
            set => _wavelength = value * (WavelengthDistance / 1000);
        }
        public double WavelengthDistance
        {
            get => _wavelengthDistance;
            set { _wavelengthDistance = value; OnPropertyChanged("Wavelength"); }
        }

        //Высота полёта носителя (км)
        public double FlightAltitude
        {
            get => _flightAltitude * (1000 / FlightAltitudeDistance);
            set => _flightAltitude = value * (FlightAltitudeDistance / 1000);
        }
        public double FlightAltitudeDistance 
        { 
            get => flightAltitudeDistance; 
            set { flightAltitudeDistance = value; OnPropertyChanged("FlightAltitude"); } 
        }

        //Скорость полёта (сканирования) (км/с)
        public double FlightSpeed
        {
            get => _flightSpeed * (1000 / FlightSpeedDistance) * (FlightSpeedTime / 1000);
            set => _flightSpeed = value * (FlightSpeedDistance / 1000) * (1000 / FlightSpeedTime);
        }
        public double FlightSpeedDistance
        {
            get => _flightSpeedDistance;
            set { _flightSpeedDistance = value; OnPropertyChanged("FlightSpeed"); }
        }
        public double FlightSpeedTime
        {
            get => _flightSpeedTime;
            set { _flightSpeedTime = value; OnPropertyChanged("FlightSpeed"); }
        }

        //Полоса обзора (км)
        
        public double Swath
        {
            get => _swath * (1000 / SwathDistance);
            set => _swath = value * (SwathDistance / 1000);
        }
        public double SwathDistance
        {
            get => _swathDistance;
            set { _swathDistance = value; OnPropertyChanged("Swath"); }
        }

        //Разрешающая способность РЛС (м)
        public double RadarResolution
        {
            get => _radarResolution * (1000 / RadarResolutionDistance);
            set => _radarResolution = value * (RadarResolutionDistance / 1000);
        }
        public double RadarResolutionDistance
        {
            get => _radarResolutionDistance;
            set { _radarResolutionDistance = value; OnPropertyChanged("RadarResolution"); }
        }

        //Максимальная дальность радиолокационного наблюдения (км)
        public double MaxRangeOfRadarSurveillance
        {
            get => _maxRangeOfRadarSurveillance * (1000 / MaxRangeOfRadarSurveillanceDistance);
            set => _maxRangeOfRadarSurveillance = value * (MaxRangeOfRadarSurveillanceDistance / 1000);
        }
        public double MaxRangeOfRadarSurveillanceDistance
        {
            get => _maxRangeOfRadarSurveillanceDistance;
            set { _maxRangeOfRadarSurveillanceDistance = value; OnPropertyChanged("MaxRangeOfRadarSurveillance"); }
        }

        //База сигнала (В)
        public double SignalBase { get; set; }

        //Раскрыв антенны в горизонтальной пл-ти (м)
        public double OpeningTheAntennasInTheHorizontal
        {
            get => _openingTheAntennasInTheHorizontal * (1000 / OpeningTheAntennasInTheHorizontalDistance);
            set => _openingTheAntennasInTheHorizontal = value * (OpeningTheAntennasInTheHorizontalDistance / 1000);
        }
        public double OpeningTheAntennasInTheHorizontalDistance
        {
            get => _openingTheAntennasInTheHorizontalDistance;
            set { _openingTheAntennasInTheHorizontalDistance = value; OnPropertyChanged("OpeningTheAntennasInTheHorizontal"); }
        }

        //Средняя частота повторений (Гц)
        public double AverageRepetitionRate { get; set; }

        //Коэффициент качества 
        public double CoefficientQuality { get; set; }

        //Коэффициент шума входного каскада
        public double CoefficientInputStageNoise { get; set; }

        //Коэффициент шума преобразователя частоты
        public double CoefficientFrequencyConverterNoise { get; set; }

        //Коэффициент шума УПЧ
        public double CoefficientYPCHNoise { get; set; }

        //Коэффициент усиления входного каскада
        public double CoefficientInputStageGain { get; set; }

        //Коэффициент передачи преобразователя частоты
        public double CoefficientFrequencyConverterTransmission { get; set; }

        //Коэффициент различимости
        public double CoefficientDistinction { get; set; }

        //Удельная ЭПР (м2)
        public double SpecificEPR { get; set; }

        //Постоянная Больцмана (Дж/К)
        public double K { get; set; } = 1.38 * Math.Pow(10, -23);


        public void Update()
        {
            BL.SpeedLight = _speedLight;
            BL.Wavelength = _wavelength;
            BL.FlightAltitude = _flightAltitude;
            BL.FlightSpeed = _flightSpeed;
            BL.Swath = _swath;
            BL.RadarResolution = _radarResolution;
            BL.MaxRangeOfRadarSurveillance = _maxRangeOfRadarSurveillance;
            BL.SignalBase = SignalBase;
            BL.OpeningTheAntennasInTheHorizontal = _openingTheAntennasInTheHorizontal;
            BL.AverageRepetitionRate = AverageRepetitionRate;
            BL.CoefficientQuality = CoefficientQuality;
            BL.CoefficientInputStageNoise = CoefficientInputStageNoise;
            BL.CoefficientFrequencyConverterNoise = CoefficientFrequencyConverterNoise;
            BL.CoefficientYPCHNoise = CoefficientYPCHNoise;
            BL.CoefficientInputStageGain = CoefficientInputStageGain;
            BL.CoefficientFrequencyConverterTransmission = CoefficientFrequencyConverterTransmission;
            BL.CoefficientDistinction = CoefficientDistinction;
            BL.SpecificEPR = SpecificEPR;
            BL.K = K;
            

        }

        //ХЛАМ разработки

        //public double GetDoubleDistance(double oldValue, DistanceEnum oldDistance, DistanceEnum newDistance)
        //{
        //    double newValue = oldValue * (int)oldDistance / (int)newDistance;
        //    return newValue;
        //}
        //public double GetDoubleTime(double oldValue, TimeEnum oldTime, TimeEnum newTime)
        //{
        //    double newValue = oldValue * (int)oldTime / (int)newTime;
        //    return newValue;
        //}
        //public double GetDoubleDistanceAndTime(double oldValue, DistanceEnum oldDistance, TimeEnum oldTime, DistanceEnum newDistance, TimeEnum newTime)
        //{
        //    double newValue = GetDoubleTime(GetDoubleDistance(oldValue, oldDistance, newDistance), newTime, oldTime);
        //    return newValue;
        //}

        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
