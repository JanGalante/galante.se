using System;
using System.Collections.Generic;

//Inne i vanlig klass
//NewsColl.Filter = new TableItemCollectionBaseFilterDelegate(RowFilterDeligate);
//rpSideResult.DataSource = NewsColl;

//Metoden (i vanlig klass)
//private bool RowFilterDeligate(DataRow row)
//{//kod
//}

//Utanför klassen i namespace:et
//public delegate bool TableItemCollectionBaseFilterDelegate(DataRow Row); //Filter

//Inne i basklassen
//public TableItemCollectionBaseFilterDelegate Filter;

//Inne i en metod i basklassen
//if (this.Filter != null) {

#region JanLundholm.Eu

/// <summary>
/// Summary description for ItemCollectionBase
/// </summary>
public class ItemCollectionBase<T> : ICollection<T> where T : new()
{
    private List<T> _dataCollection = null;

    //Deklaration av delegat
    public delegate bool FilteredCollectionDelegate(T item);
    //Instansiering av delegat
    private FilteredCollectionDelegate _filter = null;

    //Deklaration av delegat/event
    public delegate void OnItemAddedDelegate(object sender, EventArgs e);
    public delegate void OnItemRemovedDelegate(object sender, EventArgs e);
    public delegate void OnFilterChangedDelegate(object sender, EventArgs e);
    //Instansiering av delegat/event
    public event OnItemAddedDelegate OnItemAdded = null;
    public event OnItemRemovedDelegate OnItemRemoved = null;
    public event OnFilterChangedDelegate OnFilterChanged = null;

    public FilteredCollectionDelegate Filter
    {
        get { return _filter; }
        set 
        { 
            _filter = value;
            if (OnFilterChanged != null)
            {
                OnFilterChanged(this, null);
            }
        }
    }



    public List<T> DataCollection
    {
        get { return _dataCollection; }
    }

    /// <summary>
    /// Kunstruktor
    /// </summary>
    public ItemCollectionBase()
    {
        _dataCollection = new List<T>();
    }

    /// <summary>
    /// Kunstruktor
    /// </summary>
    /// <param name="data"></param>
    public ItemCollectionBase(List<T> data)
    {
        _dataCollection = data;
    }


    #region IEnumerable<T> Members

    public IEnumerator<T> GetEnumerator()
    {
        //foreach (T item in _dataCollection)
        //{
        //    yield return item;
        //}
        if (this.Filter != null)
        {
            foreach (T item in _dataCollection)
            {
                //if (filterDelegate(item))
                if (this.Filter(item))
                {
                    yield return item;
                }
                else
                {
                    continue;
                }
            }
            yield break;
        }
        else
        {
            foreach (T item in _dataCollection)
            {
                yield return item;
            }
        }
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        //throw new NotImplementedException();
        return GetEnumerator();
    }

    #endregion


    #region ICollection<T> Members

    public void Add(T item)
    {
        _dataCollection.Add(item);
        
        //Kontrollerar om några abonerar på eventet
        if (OnItemAdded != null)
        {
            OnItemAdded(item, null);
        }
    }

    public void Clear()
    { _dataCollection.Clear(); }


    public bool Contains(T item)
    { return _dataCollection.Contains(item); }


    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public int Count
    {
        get { return _dataCollection.Count; }
    }

    public bool IsReadOnly
    {
        get { throw new NotImplementedException(); }
    }

    public bool Remove(T item)
    {
        //return _dataCollection.Remove(item);
        bool isRemoved = _dataCollection.Remove(item);

        //Kontrollerar borttagning skett och 
        //om några abonerar på eventet
        if (isRemoved && OnItemRemoved != null)
        {
            OnItemRemoved(item, null);
        }
        return isRemoved;
    }

    #endregion


    public void Sort(Comparison<T> comparison)
    {
        _dataCollection.Sort(comparison);
    }

    //predicate är en istans av delegaten Predicate<T>
    // bool Predicate<T>(T obj)
    public T Find(Predicate<T> predicate)
    {
        return _dataCollection.Find(predicate);
    }
} 
#endregion