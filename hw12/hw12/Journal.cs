using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw12
{
    class Journal : IEnumerable, IEnumerator, ICollection
    {
        private Pupil firstPupil;
        private Pupil currentPupil;
        private Pupil lastPupil;

        public byte MinMark { protected set; get; }
        public byte MaxMark { protected set; get; }

        public Journal()
        {
            this.MinMark = 1;
            this.MaxMark = 12;
        }

        #region IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }
        #endregion

        #region IEnumerator
        object IEnumerator.Current
        {
            get
            {
                if (this.currentPupil != null)
                {
                    return this.currentPupil;
                }
                return null;
            }
        }

        public bool MoveNext()
        {
            if (this.currentPupil == null)
            {
                if (this.firstPupil != null)
                {
                    this.currentPupil = firstPupil;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (this.currentPupil.Next != null)
                {
                    this.currentPupil = this.currentPupil.Next;
                    return true;
                }
                else
                {
                    this.Reset();
                    return false;
                }
            }
        }
        public virtual void Reset()
        {
            this.currentPupil = null;
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            this.Reset();
        }
        #endregion

        #region ICollection
        public int Count
        {
            get
            {
                int counter = 0;
                foreach (var item in this)
                {
                    counter++;
                }
                return counter;
            }
        }
        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }
        public object SyncRoot
        {
            get
            {
                return null;
            }
        }
        void ICollection.CopyTo(Array array, int index)
        {
            int counter = 0;
            foreach (var item in this)
            {
                if (counter >= index)
                {
                    if (counter - index >= array.Length)
                        break;
                    array.SetValue(item, counter - index);
                }
                counter++;
            }
        }
        #endregion
        public Pupil Add(string nameArg, byte ageArg)
        {
            if (this.GetPupilByName(nameArg) == null ||
                this.GetPupilByName(nameArg).Age != ageArg)
            {
                Pupil newPupil = new Pupil(nameArg, ageArg);
                if (this.lastPupil == null)
                {
                    this.firstPupil = newPupil;
                    this.lastPupil = newPupil;
                }
                else
                {
                    newPupil.Prev = this.lastPupil;
                    this.lastPupil.Next = newPupil;
                    this.lastPupil = newPupil;
                }
                return newPupil;
            }
            else
            {
                return null;
            }
        }

        public void AddMark(Pupil pupilArg, string subject, byte mark)
        {
            pupilArg.AddMark(subject, mark);
        }

        public Pupil GetPupilByName(string name)
        {
            foreach (Pupil pupil in this)
            {
                if (pupil.Name == name)
                {
                    return pupil;
                }
            }
            return null;
        }
    }
}
