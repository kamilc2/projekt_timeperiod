using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_lab
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte hours;
        private readonly byte minutes;
        private readonly byte seconds;

        public byte Hours => hours;
        public byte Minutes => minutes;
        public byte Seconds => seconds;

        public Time(byte hours, byte minutes, byte seconds)
        {
            if (hours >= 24 || minutes >= 60 || seconds >= 60)
                throw new ArgumentException("Invalid time.");

            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        public Time(byte hours, byte minutes) : this(hours, minutes, 0) { }

        public Time(byte hours) : this(hours, 0, 0) { }

        public Time(string time)
        {
            var parts = time.Split(':');
            if (parts.Length < 1 || parts.Length > 3)
                throw new ArgumentException("Invalid time format.");

            var parsedHours = byte.Parse(parts[0]);
            var parsedMinutes = parts.Length > 1 ? byte.Parse(parts[1]) : (byte)0;
            var parsedSeconds = parts.Length > 2 ? byte.Parse(parts[2]) : (byte)0;

            if (parsedHours >= 24 || parsedMinutes >= 60 || parsedSeconds >= 60)
                throw new ArgumentException("Invalid time values.");

            hours = parsedHours;
            minutes = parsedMinutes;
            seconds = parsedSeconds;
        }

        public override string ToString()
        {
            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }

        public bool Equals(Time other)
        {
            return hours == other.hours && minutes == other.minutes && seconds == other.seconds;
        }

        public override bool Equals(object obj)
        {
            return obj is Time other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(hours, minutes, seconds);
        }

        public int CompareTo(Time other)
        {
            if (hours != other.hours) return hours.CompareTo(other.hours);
            if (minutes != other.minutes) return minutes.CompareTo(other.minutes);
            return seconds.CompareTo(other.seconds);
        }

        public static bool operator ==(Time left, Time right) => left.Equals(right);
        public static bool operator !=(Time left, Time right) => !left.Equals(right);
        public static bool operator <(Time left, Time right) => left.CompareTo(right) < 0;
        public static bool operator <=(Time left, Time right) => left.CompareTo(right) <= 0;
        public static bool operator >(Time left, Time right) => left.CompareTo(right) > 0;
        public static bool operator >=(Time left, Time right) => left.CompareTo(right) >= 0;

        public Time Plus(TimePeriod period)
        {
            long totalSeconds = hours * 3600L + minutes * 60L + seconds + period.TotalSeconds;
            totalSeconds %= 86400;
            byte newHours = (byte)(totalSeconds / 3600L);
            byte newMinutes = (byte)((totalSeconds / 60L) % 60);
            byte newSeconds = (byte)(totalSeconds % 60);
            return new Time(newHours, newMinutes, newSeconds);
        }

        public static Time operator +(Time time, TimePeriod period) => time.Plus(period);
    }
}
