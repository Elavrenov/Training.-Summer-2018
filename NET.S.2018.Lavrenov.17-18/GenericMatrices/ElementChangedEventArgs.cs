namespace GenericMatrices
{
    using System;

    /// <summary>
    /// events agrs class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ElementChangedEventArgs<T> : EventArgs
    {
        #region Props

        public int Row { get; }
        public int Column { get; }
        public T OldValue { get; }
        public T NewValue { get; }

        #endregion

        #region Ctor
        public ElementChangedEventArgs(int i, int j, T oldValue, T newValue)
        {
            Row = i;
            Column = j;
            OldValue = oldValue;
            NewValue = newValue;
        }

        #endregion
    }
}
