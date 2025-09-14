
namespace oap_1;

abstract class BoundedStack<T>
{
    public const int POP_NIL = 0; // команда push() не вызывалась
    public const int POP_OK = 1; // команда pop() отработала нормально
    public const int POP_ERR = 2; // стек пуст

    public const int PEEK_NIL = 0; // команда push() не вызывалась
    public const int PEEK_OK = 1; // запрос peek() отработал нормально
    public const int PEEK_ERR = 2; // стек пуст

    public const int PUSH_NIL = 0; // команда push() не вызывалась
    public const int PUSH_OK = 1; // команда push() отработала нормально
    public const int PUSH_ERR = 2; // превышен размер стека командой push()

    // конструктор
    // постусловие: создан новый пустой стек
    public BoundedStack()
    {
    }

    public BoundedStack(int size)
    {
    }

    // команды:

    // постусловие: из стека удалятся все значения
    public abstract void Clear();

    // предусловие: добавление нового элемента не превышает допустимый размер стека;
    // постусловие: в стек добавлено новое значение
    public abstract void Push(T value);

    // предусловие: стек не пустой;
    // постусловие: из стека удалён верхний элемент
    public abstract void Pop();


    // запросы:

    // предусловие: стек не пустой
    public abstract T Peek();
    public abstract int Size();

    // дополнительные запросы:
    public abstract int GetPopStatus(); // возвращает значение POP_*
    public abstract int GetPeekStatus(); // возвращает значение PEEK_*
    public abstract int GetPushStatus(); // возвращает значение PUSH_*
}

class BoundedStackArray<T> : BoundedStack<T>
{
    private const int DEFAULT_SIZE = 32; // размер стека по умолчанию

    private List<T> _stack; // список для хранения значений стека
    private int _maxSize; // максимальный размер стека

    private int _popStatus; // статус последней операции pop
    private int _peekStatus; // статус последней операции peek
    private int _pushStatus; // статус последней операции push

    // конструктор
    // постусловие: создан новый пустой стек
    public BoundedStackArray() : this(DEFAULT_SIZE)
    {
    }

    public BoundedStackArray(int size)
    {
        _maxSize = size <= 0 ? DEFAULT_SIZE : size;
        _stack = new List<T>(_maxSize);
        ResetStatuses();
    }

    public override void Clear()
    {
        _stack = new List<T>(_maxSize);
        ResetStatuses();
    }

    public override void Pop()
    {
        if (Size() > 0)
        {
            _stack.RemoveAt(Size() - 1);
            _popStatus = POP_OK;
            return;
        }

        _popStatus = POP_ERR;
    }

    public override void Push(T value)
    {
        if (Size() < _maxSize)
        {
            _stack.Add(value);
            _pushStatus = PUSH_OK;
            return;
        }

        _pushStatus = PUSH_ERR;
    }

    public override T Peek()
    {
        if (Size() > 0)
        {
            _peekStatus = PEEK_OK;
            return _stack[Size() - 1];
        }

        _peekStatus = PEEK_ERR;
        return default;
    }

    public override int Size() => _stack.Count;

    public override int GetPopStatus() => _popStatus;
    public override int GetPeekStatus() => _peekStatus;
    public override int GetPushStatus() => _pushStatus;

    private void ResetStatuses()
    {
        _popStatus = POP_NIL;
        _peekStatus = PEEK_NIL;
        _pushStatus = PUSH_NIL;
    }
}