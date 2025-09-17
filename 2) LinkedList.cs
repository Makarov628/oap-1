public abstract class LinkedList<T>
{
    public const int HEAD_OK = 1;  // курсор установили на первый узел
    public const int HEAD_ERR = 2; // список пуст

    public const int TAIL_OK = 1;  // курсор установили на последний узел
    public const int TAIL_ERR = 2; // список пуст

    public const int RIGHT_OK = 1;  // курсор успешно сдвинут
    public const int RIGHT_ERR_EMPTY = 2; // список пуст
    public const int RIGHT_ERR_LAST = 3; // курсор установлен на последний элемент

    public const int REMOVE_OK = 1; // текущий узел успешно удален и курсор сдвинут
    public const int REMOVE_ERR = 2; // список пуст

    public const int REPLACE_OK = 1; // значение узла изменено
    public const int REPLACE_ERR = 2; // список пуст

    public const int FIND_OK = 1; // курсор сдвинут на узел с переданным значением
    public const int FIND_ERR_EMPTY = 2; // список пуст
    public const int FIND_ERR_NOTFOUND = 3; // переданное значение не найдено

    public const int REMOVEALL_OK = 1; // удалены все переданные значения
    public const int REMOVEALL_ERR = 2; // список пуст

    #region Команды

    /// <summary>
    /// установить курсор на первый узел в списке <br/>
    /// <br/> предусловие: список не пустой
    /// <br/> постусловие: курсор установлен на первый узел в списке
    /// </summary>
    public abstract void Head();

    /// <summary>
    /// установить курсор на последний узел в списке <br/>
    /// <br/> предусловие: список не пустой
    /// <br/> постусловие: курсор установлен на первый узел в списке
    /// </summary>
    public abstract void Tail();

    /// <summary>
    /// сдвинуть курсор на один узел вправо <br/>
    /// <br/> предусловие: элемент справа от курсора существует <br/>
    /// <br/> постусловие: курсор сдвинут на один узел вправо
    /// </summary>
    public abstract void Right();

    /// <summary>
    /// вставить элемент после текущего узла <br/>
    /// <br/> постусловие: новый узел добавлен первым если список был пуст, или следующим после текущего
    /// </summary>
    public abstract void PutRight(T value);

    /// <summary>
    /// вставить элемент перед текущим узлом <br/>
    /// <br/> постусловие: новый узел добавлен первым если список был пуст, или предыдущим перед текущим
    /// </summary>
    public abstract void PutLeft(T value);

    /// <summary>
    /// удалить текущий узел <br/>
    /// <br/> предусловие: список не пустой
    /// <br/> постусловие: удален текущий узел, курсор переместился либо направо, либо налево, либо никуда не указывает
    /// </summary>
    public abstract void Remove();

    /// <summary>
    /// очистить список <br/>
    /// <br/> постусловие: список очищен, курсор никуда не указывает
    /// </summary>
    public abstract void Clear();

    /// <summary>
    /// добавить новый узел в хвост списка <br/>
    /// <br/> постусловие: новый узел добавлен в хвост списка
    /// </summary>
    public abstract void AddTail(T value);

    /// <summary>
    /// заменить значение текущего узла на заданное <br/>
    /// <br/> предусловие: список не пустой
    /// <br/> постусловие: значение текущего узла изменено на заданное
    /// </summary>
    public abstract void Replace(T value);

    /// <summary>
    /// установить курсор на следующий узел с искомым значением (по отношению к текущему узлу) <br/>
    /// <br/> постусловие: курсор установлен на узел с искомым значением или курсор не установлен
    /// </summary>
    public abstract void Find(T value);

    /// <summary>
    /// удалить в списке все узлы с заданным значением <br/>
    /// <br/> предусловие: список не пустой
    /// <br/> постусловие: из списка удалены все узлы с заданным значением
    /// </summary>
    public abstract void RemoveAll(T value);

    #endregion

    #region Запросы

    /// <summary>
    /// получить значение текущего узла
    /// <br/> предусловие: список не пустой
    /// </summary>
    public abstract T Get();

    /// <summary>
    /// посчитать количество узлов в списке
    /// </summary>
    public abstract int Size();

    /// <summary>
    /// находится ли курсор в начале списка?
    /// <br/> предусловие: список не пустой
    /// </summary>
    public abstract bool IsHead();

    /// <summary>
    /// находится ли курсор в конце списка?
    /// <br/> предусловие: список не пустой
    /// </summary>
    public abstract bool IsTail();

    /// <summary>
    /// установлен ли курсор на какой-либо узел в списке (по сути, непустой ли список)
    /// </summary>
    public abstract bool IsValue();

    #endregion

    public abstract int Get_Head_Status();
    public abstract int Get_Tail_Status();
    public abstract int Get_Right_Status();
    public abstract int Get_Remove_Status();
    public abstract int Get_Replace_Status();
    public abstract int Get_Find_Status();
    public abstract int Get_RemoveAll_Status();
}