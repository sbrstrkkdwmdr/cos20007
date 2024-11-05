namespace CounterTask
{
    public class Counter
    {
        private long _count; //had to change _count to a long because method ResetByDefault(); puts the value over the 32-bit signed integer limit
        private string _name;
        public Counter(string name) {
            _name = name;
            _count = 0;
        }

        public void Increment()
        {
            _count++;
        }

        public void Reset()
        {
        _count = 0; 
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public long Tick
        {
        get { return _count; } 
        }

        public void ResetByDefault()
        {
            _count = 2147483647002;
        }
    }
}
