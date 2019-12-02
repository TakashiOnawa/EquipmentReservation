using EquipmentReservation.Framework.Domain;
using System;
using System.Collections.Generic;

namespace EquipmentReservation.Domain.Reservations
{
    public class ReservationDateTime : IValueObject
    {
        public ReservationDateTime(DateTime start, DateTime end)
        {
            if (start.CompareTo(end) >= 0) throw new ArgumentException("終了日時は開始日時よりも後にしてください。");
            Start = start;
            End = end;
        }

        public DateTime Start { get; }
        public DateTime End { get; }

        public bool IsRangeOverlapping(ReservationDateTime other)
        {
            Assertion.ArgumentNotNull(other, nameof(other));
            var compareResultStart = Start.CompareTo(other.Start);
            var compareResultEnd = End.CompareTo(other.End);

            return Start.CompareTo(other.End) < 0 && other.Start.CompareTo(End) < 0; 
        }

        public override bool Equals(object obj)
        {
            var time = obj as ReservationDateTime;
            return time != null &&
                   Start == time.Start &&
                   End == time.End;
        }

        public override int GetHashCode()
        {
            var hashCode = -1676728671;
            hashCode = hashCode * -1521134295 + Start.GetHashCode();
            hashCode = hashCode * -1521134295 + End.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(ReservationDateTime time1, ReservationDateTime time2)
        {
            return EqualityComparer<ReservationDateTime>.Default.Equals(time1, time2);
        }

        public static bool operator !=(ReservationDateTime time1, ReservationDateTime time2)
        {
            return !(time1 == time2);
        }
    }
}
