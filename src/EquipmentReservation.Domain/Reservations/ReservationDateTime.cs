using EquipmentReservation.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Domain.Reservations
{
    public class ReservationDateTime : IEquatable<ReservationDateTime>
    {
        public ReservationDateTime(DateTime start, DateTime end)
        {
            if (start.CompareTo(end) >= 0) throw new ArgumentException("終了日時は開始日時よりも後にしてください。");
            Start = start;
            End = end;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public bool IsRangeOverlapping(ReservationDateTime other)
        {
            Assertion.ArgumentNotNull(other, nameof(other));
            var compareResultStart = Start.CompareTo(other.Start);
            var compareResultEnd = End.CompareTo(other.End);

            return Start.CompareTo(other.End) < 0 && other.Start.CompareTo(End) < 0; 
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ReservationDateTime);
        }

        public bool Equals(ReservationDateTime other)
        {
            return other != null &&
                   Start == other.Start &&
                   End == other.End;
        }

        public override int GetHashCode()
        {
            var hashCode = -1676728671;
            hashCode = hashCode * -1521134295 + Start.GetHashCode();
            hashCode = hashCode * -1521134295 + End.GetHashCode();
            return hashCode;
        }
    }
}
