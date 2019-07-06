using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Domain.Reservations
{
    public class ReservationDateTime : IEquatable<ReservationDateTime>
    {
        public ReservationDateTime(DateTime start, DateTime end)
        {
            if (start.CompareTo(end) <= 0) throw new ArgumentException("終了時間は開始時間よりも後の時間にしてください。");
            Start = start;
            End = end;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public bool IsRangeOverlapping(ReservationDateTime other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            var compareResultStart = Start.CompareTo(other.Start);
            var compareResultEnd = End.CompareTo(other.End);

            if (compareResultStart <= 0 && compareResultEnd <= 0) return true;
            if (compareResultStart >= 0 && compareResultEnd >= 0) return true;
            return false;
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
