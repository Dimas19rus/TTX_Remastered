using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    [Serializable()]
    public class WindowResultModel : MainWindowModel, INotifyPropertyChanged
    {

        public WindowResultModel()
        {

        }

        private double _notVisibleArea;
        private double _notVisibleAreaDistance;

        private double _minHorizontalRange;
        private double _minHorizontalRangeDistance;

        private double _maxHorizontalRange;
        private double _maxHorizontalRangeDistance;

        private double _minRangeOfRadarSurveillance;
        private double _minRangeOfRadarSurveillanceDistance;

        private double _minSightingAngle;
        private double _minSightingAngleMeasureOfАngle;

        private double _maxSightingAngle;
        private double _maxSightingAngleMeasureOfАngle;

        private double _observationBandwidth;
        private double _observationBandwidthDistance;

        private double _signalDuration;
        private double _signalDurationTime;

        public double _frequencyDeviation;
        
        private double _probingPulseDuration;
        private double _probingPulseDurationTime;

        public double _upperLimitOfPulseFrequency;

        public double _lowerLimitOfPulseFrequency;

        public string _pulseRepetitionRate;

        private double _correctedSignalDuration;
        private double _correctedSignalDurationTime;

        private double _antennaBeamwidthInTheVertical;
        private double _antennaBeamwidthInTheVerticalMeasureOfАngle;

        private double _antennaBeamwidthInTheHorizontal;
        private double _antennaBeamwidthInTheHorizontalMeasureOfАngle;

        private double _openingTheAntennasInTheVertical;
        private double _openingTheAntennasInTheVerticalDistance;

        private double _lowerBoundaryOfTheAntenna;
        private double _lowerBoundaryOfTheAntennaDistance;

        private double _upperBoundaryOfTheAntenna;
        private double _upperBoundaryOfTheAntennaDistance;

        private double _lowerBoundaryOfTheAntennaNumbers;
        private double _lowerBoundaryOfTheAntennaNumbersDistance;

        private double _antennaSectorWidth;
        private double _antennaSectorWidthMeasureOfАngle;

        private double _noiseTemperature;
        private double _noiseTemperatureTemp;

        public double _coefficientAntennaAction;

        public double _energySpectrum;

        public double _dopplerSpectrumWidth;

        public double _noiseStripe;

        public double _coefficientNoise;

        private double _noisePower;

        private double _radioSensitivity;

        private double _receiverBandwidth;

        private double _effectiveScatteringAreaOfDrySteppe;



        public double NotVisibleArea
        {
            get => _notVisibleArea * (1000 / NotVisibleAreaDistance);
            set { _notVisibleArea = value * (NotVisibleAreaDistance / 1000); OnPropertyChanged("NotVisibleArea"); }
        }
        public double NotVisibleAreaDistance
        {
            get => _notVisibleAreaDistance;
            set { _notVisibleAreaDistance = value; OnPropertyChanged("NotVisibleArea"); }
        }

        public double MinHorizontalRange
        {
            get => _minHorizontalRange * (1000 / MinHorizontalRangeDistance);
            set { _minHorizontalRange = value * (MinHorizontalRangeDistance / 1000); OnPropertyChanged("MinHorizontalRange"); }
        }
        public double MinHorizontalRangeDistance
        {
            get => _minHorizontalRangeDistance;
            set { _minHorizontalRangeDistance = value; OnPropertyChanged("MinHorizontalRange"); }
        }

        public double MaxHorizontalRange
        {
            get => _maxHorizontalRange * (1000 / MaxHorizontalRangeDistance);
            set { _maxHorizontalRange = value * (MaxHorizontalRangeDistance / 1000); OnPropertyChanged("MaxHorizontalRange"); }
        }
        public double MaxHorizontalRangeDistance
        {
            get => _maxHorizontalRangeDistance;
            set { _maxHorizontalRangeDistance = value; OnPropertyChanged("MaxHorizontalRange"); }
        }

        public double MinRangeOfRadarSurveillance
        {
            get => _minRangeOfRadarSurveillance * (1000 / MinRangeOfRadarSurveillanceDistance);
            set { _minRangeOfRadarSurveillance = value * (MinRangeOfRadarSurveillanceDistance / 1000); OnPropertyChanged("MinRangeOfRadarSurveillance"); }
        }
        public double MinRangeOfRadarSurveillanceDistance
        {
            get => _minRangeOfRadarSurveillanceDistance;
            set { _minRangeOfRadarSurveillanceDistance = value; OnPropertyChanged("MinRangeOfRadarSurveillance"); }
        }

        public double MinSightingAngle
        {
            get => _minSightingAngle * MinSightingAngleMeasureOfАngle;
            set { _minSightingAngle = value / MinSightingAngleMeasureOfАngle; OnPropertyChanged("MinSightingAngle"); }
        }
        public double MinSightingAngleMeasureOfАngle
        {
            get => _minSightingAngleMeasureOfАngle;
            set { _minSightingAngleMeasureOfАngle = value; OnPropertyChanged("MinSightingAngle"); }
        }

        public double MaxSightingAngle
        {
            get => _maxSightingAngle * MaxSightingAngleMeasureOfАngle;
            set { _maxSightingAngle = value / MaxSightingAngleMeasureOfАngle; OnPropertyChanged("MaxSightingAngle"); }
        }
        public double MaxSightingAngleMeasureOfАngle
        {
            get => _maxSightingAngleMeasureOfАngle;
            set { _maxSightingAngleMeasureOfАngle = value; OnPropertyChanged("MaxSightingAngle"); }
        }

        public double ObservationBandwidth
        {
            get => _observationBandwidth * (1000 / ObservationBandwidthDistance);
            set { _observationBandwidth = value * (ObservationBandwidthDistance / 1000); OnPropertyChanged("ObservationBandwidth"); }
        }
        public double ObservationBandwidthDistance
        {
            get => _observationBandwidthDistance;
            set { _observationBandwidthDistance = value; OnPropertyChanged("ObservationBandwidth"); }
        }


        public double SignalDuration
        {
            get => _signalDuration * (1000 / SignalDurationTime);
            set { _signalDuration = value * (SignalDurationTime / 1000); OnPropertyChanged("SignalDuration"); }
        }
        public double SignalDurationTime
        {
            get => _signalDurationTime;
            set { _signalDurationTime = value; OnPropertyChanged("SignalDuration"); }
        }


        public double FrequencyDeviation
        {
            get => _frequencyDeviation;
            set { _frequencyDeviation = value; OnPropertyChanged("FrequencyDeviation"); }
        }

        public double ProbingPulseDuration
        {
            get => _probingPulseDuration * (1000 / ProbingPulseDurationTime);
            set { _probingPulseDuration = value * (ProbingPulseDurationTime / 1000); OnPropertyChanged("ProbingPulseDuration"); }
        }
        public double ProbingPulseDurationTime
        {
            get => _probingPulseDurationTime;
            set { _probingPulseDurationTime = value; OnPropertyChanged("ProbingPulseDuration"); }
        }


        public double UpperLimitOfPulseFrequency
        {
            get => _upperLimitOfPulseFrequency;
            set { _upperLimitOfPulseFrequency = value; OnPropertyChanged("UpperLimitOfPulseFrequency"); }
        }
        public double LowerLimitOfPulseFrequency
        {
            get => _lowerLimitOfPulseFrequency;
            set { _lowerLimitOfPulseFrequency = value; OnPropertyChanged("LowerLimitOfPulseFrequency"); }
        }
        public string PulseRepetitionRate
        {
            get => _pulseRepetitionRate;
            set { _pulseRepetitionRate = value; OnPropertyChanged("PulseRepetitionRate"); }
        }

        public double CorrectedSignalDuration
        {
            get => _correctedSignalDuration * (1000 / CorrectedSignalDurationTime);
            set { _correctedSignalDuration = value * (CorrectedSignalDurationTime / 1000); UpdateFrequencyDeviation(); OnPropertyChanged("CorrectedSignalDuration");  }
        }
        public double CorrectedSignalDurationTime
        {
            get => _correctedSignalDurationTime;
            set { _correctedSignalDurationTime = value; OnPropertyChanged("CorrectedSignalDuration"); }
        }

        public double AntennaBeamwidthInTheVertical
        {
            get => _antennaBeamwidthInTheVertical * AntennaBeamwidthInTheVerticalMeasureOfАngle;
            set { _antennaBeamwidthInTheVertical = value / AntennaBeamwidthInTheVerticalMeasureOfАngle; OnPropertyChanged("AntennaBeamwidthInTheVertical"); }
        }
        public double AntennaBeamwidthInTheVerticalMeasureOfАngle
        {
            get => _antennaBeamwidthInTheVerticalMeasureOfАngle;
            set { _antennaBeamwidthInTheVerticalMeasureOfАngle = value; OnPropertyChanged("AntennaBeamwidthInTheVertical"); }
        }

        public double AntennaBeamwidthInTheHorizontal
        {
            get => _antennaBeamwidthInTheHorizontal * AntennaBeamwidthInTheHorizontalMeasureOfАngle;
            set { _antennaBeamwidthInTheHorizontal = value / AntennaBeamwidthInTheHorizontalMeasureOfАngle; OnPropertyChanged("AntennaBeamwidthInTheHorizontal"); }
        }
        public double AntennaBeamwidthInTheHorizontalMeasureOfАngle
        {
            get => _antennaBeamwidthInTheHorizontalMeasureOfАngle;
            set { _antennaBeamwidthInTheHorizontalMeasureOfАngle = value; OnPropertyChanged("AntennaBeamwidthInTheHorizontal"); }
        }

        public double OpeningTheAntennasInTheVertical
        {
            get => _openingTheAntennasInTheVertical * (1000 / OpeningTheAntennasInTheVerticalDistance);
            set { _openingTheAntennasInTheVertical = value * (OpeningTheAntennasInTheVerticalDistance / 1000); OnPropertyChanged("OpeningTheAntennasInTheVertical"); }
        }
        public double OpeningTheAntennasInTheVerticalDistance
        {
            get => _openingTheAntennasInTheVerticalDistance;
            set { _openingTheAntennasInTheVerticalDistance = value; OnPropertyChanged("OpeningTheAntennasInTheVertical"); }
        }

        public double LowerBoundaryOfTheAntenna
        {
            get => _lowerBoundaryOfTheAntenna * (1000 / LowerBoundaryOfTheAntennaDistance);
            set { _lowerBoundaryOfTheAntenna = value * (LowerBoundaryOfTheAntennaDistance / 1000); OnPropertyChanged("LowerBoundaryOfTheAntenna"); }
        }
        public double LowerBoundaryOfTheAntennaDistance
        {
            get => _lowerBoundaryOfTheAntennaDistance;
            set { _lowerBoundaryOfTheAntennaDistance = value; OnPropertyChanged("LowerBoundaryOfTheAntenna"); }
        }

        public double UpperBoundaryOfTheAntenna
        {
            get => _upperBoundaryOfTheAntenna * (1000 / UpperBoundaryOfTheAntennaDistance);
            set { _upperBoundaryOfTheAntenna = value * (UpperBoundaryOfTheAntennaDistance / 1000); OnPropertyChanged("UpperBoundaryOfTheAntenna"); }
        }
        public double UpperBoundaryOfTheAntennaDistance
        {
            get => _upperBoundaryOfTheAntennaDistance;
            set { _upperBoundaryOfTheAntennaDistance = value; OnPropertyChanged("UpperBoundaryOfTheAntenna"); }
        }

        public double LowerBoundaryOfTheAntennaNumbers
        {
            get => _lowerBoundaryOfTheAntennaNumbers * (1000 / LowerBoundaryOfTheAntennaNumbersDistance);
            set { _lowerBoundaryOfTheAntennaNumbers = value * (LowerBoundaryOfTheAntennaNumbersDistance / 1000); OnPropertyChanged("LowerBoundaryOfTheAntennaNumbers"); }
        }
        public double LowerBoundaryOfTheAntennaNumbersDistance
        {
            get => _lowerBoundaryOfTheAntennaNumbersDistance;
            set { _lowerBoundaryOfTheAntennaNumbersDistance = value; OnPropertyChanged("LowerBoundaryOfTheAntennaNumbers"); }
        }

        public double AntennaSectorWidth
        {
            get => _antennaSectorWidth * AntennaSectorWidthMeasureOfАngle;
            set { _antennaSectorWidth = value / AntennaSectorWidthMeasureOfАngle; OnPropertyChanged("AntennaSectorWidth"); }
        }
        public double AntennaSectorWidthMeasureOfАngle
        {
            get => _antennaSectorWidthMeasureOfАngle;
            set { _antennaSectorWidthMeasureOfАngle = value; OnPropertyChanged("AntennaSectorWidth"); }
        }

        public double CoefficientAntennaAction
        {
            get => _coefficientAntennaAction;
            set { _coefficientAntennaAction = value; OnPropertyChanged("CoefficientAntennaAction"); }
        }
        public double EnergySpectrum
        {
            get => _energySpectrum;
            set { _energySpectrum = value; OnPropertyChanged("EnergySpectrum"); }
        }
        public double DopplerSpectrumWidth
        {
            get => _dopplerSpectrumWidth;
            set { _dopplerSpectrumWidth = value; OnPropertyChanged("DopplerSpectrumWidth"); }
        }
        public double NoiseStripe
        {
            get => _noiseStripe;
            set { _noiseStripe = value; OnPropertyChanged("NoiseStripe"); }
        }
        public double CoefficientNoise
        {
            get => _coefficientNoise;
            set { _coefficientNoise = value; OnPropertyChanged("CoefficientNoise"); }
        }

        
        public double NoiseTemperature
        {
            get => _noiseTemperature - NoiseTemperatureTemp;
            set { _noiseTemperature = value + NoiseTemperatureTemp; OnPropertyChanged("NoiseTemperature"); }
        }
        public double NoiseTemperatureTemp
        {
            get => _noiseTemperatureTemp;
            set { _noiseTemperatureTemp = value; OnPropertyChanged("NoiseTemperature"); }
        }
        public double NoisePower
        {
            get => _noisePower;
            set { _noisePower = value; OnPropertyChanged("NoisePower"); }
        }
        public double RadioSensitivity
        {
            get => _radioSensitivity;
            set { _radioSensitivity = value; OnPropertyChanged("RadioSensitivity"); }
        }
        public double ReceiverBandwidth
        {
            get => _receiverBandwidth;
            set { _receiverBandwidth = value; OnPropertyChanged("ReceiverBandwidth"); }
        }
        public double EffectiveScatteringAreaOfDrySteppe
        {
            get => _effectiveScatteringAreaOfDrySteppe;
            set { _effectiveScatteringAreaOfDrySteppe = value; OnPropertyChanged("EffectiveScatteringAreaOfDrySteppe"); }
        }

        
        public void UpdateFrequencyDeviation()
        {
            BL.CorrectedSignalDuration = _correctedSignalDuration;
            FrequencyDeviation = BL.FrequencyDeviation();
        }

        public new void Update()
        {
            base.Update();
            BL.CorrectedSignalDuration = _correctedSignalDuration;
            _notVisibleArea = BL.NotVisibleArea();
            _minHorizontalRange = BL.MinHorizontalRange();
            _maxHorizontalRange = BL.MaxHorizontalRange();
            _minRangeOfRadarSurveillance = BL.MinRangeOfRadarSurveillance();
            _minSightingAngle = BL.MinSightingAngle();
            _maxSightingAngle = BL.MaxSightingAngle();
            _observationBandwidth = BL.ObservationBandwidth();
            _signalDuration = BL.SignalDuration();
            _frequencyDeviation = BL.FrequencyDeviation();
            _probingPulseDuration = BL.ProbingPulseDuration();
            _upperLimitOfPulseFrequency = BL.UpperLimitOfPulseFrequency();
            _lowerLimitOfPulseFrequency = BL.LowerLimitOfPulseFrequency();
            _pulseRepetitionRate = BL.PulseRepetitionRate();
            if(_correctedSignalDuration == default(double))
            {
                _correctedSignalDuration = BL.GetCorrectedSignalDuration();
            }
            _antennaBeamwidthInTheVertical = BL.AntennaBeamwidthInTheVertical();
            _antennaBeamwidthInTheHorizontal = BL.AntennaBeamwidthInTheHorizontal();
            _openingTheAntennasInTheVertical = BL.OpeningTheAntennasInTheVertical();
            _lowerBoundaryOfTheAntenna = BL.LowerBoundaryOfTheAntenna();
            _upperBoundaryOfTheAntenna = BL.UpperBoundaryOfTheAntenna();
            _lowerBoundaryOfTheAntennaNumbers = BL.LowerBoundaryOfTheAntennaNumbers();
            _antennaSectorWidth = BL.AntennaSectorWidth();
            _coefficientAntennaAction = BL.CoefficientAntennaAction();
            _energySpectrum = BL.EnergySpectrum();
            _dopplerSpectrumWidth = BL.DopplerSpectrumWidth();
            _noiseStripe = BL.NoiseStripe();
            _coefficientNoise = BL.CoefficientNoise();
            _noiseTemperature = BL.NoiseTemperature();
            _noisePower = BL.NoisePower();
            _radioSensitivity = BL.RadioSensitivity();
            _receiverBandwidth = BL.ReceiverBandwidth();
            _effectiveScatteringAreaOfDrySteppe = BL.EffectiveScatteringAreaOfDrySteppe();
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


    }
}
