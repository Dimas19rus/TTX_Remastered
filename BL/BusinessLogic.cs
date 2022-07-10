using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    [Serializable()]
    public class BusinessLogic
    {
        //Скорость света
        public double SpeedLight { get; set; }  // единица измерения м/c

        //Постоянная Больцмана Дж/К
        public double K { get; set; }

        //Длина рабочей волны 
        public double Wavelength { get; set; }

        //Высота полёта носителя 
        public double FlightAltitude { get; set; }

        //Скорость полёта (сканирования) 
        public double FlightSpeed { get; set; }

        //Полоса обзора 
        public double Swath { get; set; }

        //Разрешающая способность РЛС
        public double RadarResolution { get; set; }

        //Максимальная дальность радиолокационного наблюдения
        public double MaxRangeOfRadarSurveillance { get; set; }

        //База сигнала
        public double SignalBase { get; set; }

        //Раскрыв антенны в горизонтальной пл-ти
        public double OpeningTheAntennasInTheHorizontal { get; set; }

        //Средняя частота повторений
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

        //Удельная ЭПР
        public double SpecificEPR { get; set; }

        //Длительность сигнала с поправкой
        public double CorrectedSignalDuration { get; set; }

        public double NotVisibleArea()
        {
            return Math.Abs(FlightAltitude - 2 * FlightAltitude);
        }
        public double MinHorizontalRange()
        {
            return NotVisibleArea();
        }
        public double MaxHorizontalRange()
        {
            var b = MinSightingAngle();
            var a = Math.Cos(MinSightingAngle());
            return MaxRangeOfRadarSurveillance * Math.Cos(MinSightingAngle());
        }
        public double MinRangeOfRadarSurveillance()
        {
            return Math.Sqrt(Math.Pow(FlightAltitude, 2) + Math.Pow(NotVisibleArea(), 2));
        }
        public double MinSightingAngle()
        {
            double a = FlightAltitude / MaxRangeOfRadarSurveillance;
            //double bmin = Math.Atan(a / Math.Sqrt(-Math.Pow(a, 2) + 1));
            double bmin = Math.Asin(a);
            return bmin;
        }
        public double MaxSightingAngle()
        {
            double a = FlightAltitude / MinHorizontalRange();
            double bmax = Math.Atan(a);
            return bmax;
        }
        public double ObservationBandwidth()
        {
            return MaxHorizontalRange() - MinHorizontalRange();
        }
        public double SignalDuration()
        {
            
            return (2 * RadarResolution * Math.Cos(MaxSightingAngle())) / SpeedLight ;
        }
        public double FrequencyDeviation()
        {
            return 1 / CorrectedSignalDuration;
        }
        public double ProbingPulseDuration()
        {
            return SignalBase / FrequencyDeviation();
        }
        public double UpperLimitOfPulseFrequency()
        {
            return Math.Pow(Math.Sin(MinSightingAngle()) / Math.Sin(MaxSightingAngle()), 2) * (SpeedLight / (2 * Swath * Math.Cos(MinSightingAngle())));
        }
        public double LowerLimitOfPulseFrequency()
        {
            return FlightSpeed / RadarResolution;
        }
        public string PulseRepetitionRate()
        {
            return "[" + LowerLimitOfPulseFrequency() + ";" + UpperLimitOfPulseFrequency() + "]";
        }
        public double GetCorrectedSignalDuration()
        {
            return SignalDuration() - 0.171*Math.Pow(10,-7);
        }
        public double AntennaBeamwidthInTheVertical()
        {
            double a = Swath * (Math.Pow(Math.Sin(MaxSightingAngle()), 2) / FlightAltitude);
            return a;
        }
        public double AntennaBeamwidthInTheHorizontal()
        {
            double a = Wavelength / OpeningTheAntennasInTheHorizontal;
            return a;
        }
        public double OpeningTheAntennasInTheVertical()
        {
            return Wavelength / AntennaBeamwidthInTheVertical();
        }

        public double LowerBoundaryOfTheAntenna()
        {
            return (4 * FlightSpeed) / AverageRepetitionRate;
        }
        public double UpperBoundaryOfTheAntenna()
        {
            return 2 * RadarResolution;
        }
        public double LowerBoundaryOfTheAntennaNumbers()
        {
            return LowerBoundaryOfTheAntenna() / 2;
        }
        public double AntennaSectorWidth()
        {
            double a = Wavelength / (2 * RadarResolution);
            return a;
        }
        public double CoefficientAntennaAction()
        {
            return (4 * Math.PI * CoefficientQuality * OpeningTheAntennasInTheHorizontal * OpeningTheAntennasInTheVertical()) / Math.Pow(Wavelength, 2);
        }
        public double EnergySpectrum()
        {
            return FrequencyDeviation();
        }
        public double DopplerSpectrumWidth()
        {
            return (FlightSpeed * AntennaSectorWidth()) / Wavelength;
        }
        public double NoiseStripe()
        {
            var a = ReceiverBandwidth();
            return 1.1 * ReceiverBandwidth();
        }
        public double CoefficientNoise()
        {
            return CoefficientInputStageNoise + (CoefficientFrequencyConverterNoise - 1) / CoefficientInputStageGain + (CoefficientYPCHNoise - 1) / (CoefficientInputStageGain * CoefficientFrequencyConverterTransmission);
        }
        public double NoiseTemperature()
        {
            var a = CoefficientNoise();
            return 290 * CoefficientNoise();
        }
        public double NoisePower()
        {
            var a = NoiseStripe();
            var b = NoiseTemperature();
            return K * NoiseStripe() * NoiseTemperature();
        }
        public double RadioSensitivity()
        {
            return CoefficientDistinction * NoisePower();
        }
        public double ReceiverBandwidth()
        {
            return FrequencyDeviation();
        }
        public double EffectiveScatteringAreaOfDrySteppe()
        {
            return SpecificEPR * Math.Pow(10, -3) * Math.Pow(RadarResolution, 2);
        }



    }
}
