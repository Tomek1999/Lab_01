using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        ObservableList1 list = new ObservableList1();
        list.Added += (object sender, ChangedEventArgs e) =>
         {
             Console.WriteLine("1:Added: value=" + e.Value);
         };
        list.Add(+1);
    }
}



public class ObservableList1
{

    private int value;
    private List<int> list = new List<int>();

    public event EventHandler<ChangedEventArgs> Added;

    protected virtual void OnChanged(ChangedEventArgs e) 
    {
        EventHandler<ChangedEventArgs> handler = this.Added;

        if (handler != null)
            handler(this, e);
    }

    public void Add(int value) {
        this.list.Add(value);
        this.OnChanged(new ChangedEventArgs(this.value));
    }

}
public class ChangedEventArgs : EventArgs
{
    public int Value { get; set; }

    public ChangedEventArgs(int value)
    {
        this.Value = value;
    }
}

