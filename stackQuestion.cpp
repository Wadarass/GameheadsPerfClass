class IntegerStack
{
    public:
        IntegerStack(int capacity);
        ~IntegerStack();

        void Push(int value);
        int Pop();

private:

    struct Node
    {
        int value;
        Node* next;
    };

    Node* m_top = null;
    int size;
};

IntegerStack::IntegerStack()
{
    m_top = null;
}

IntegerStack::~IntegerStack()
{
    while( m_top != null )
    {
        Node* next = m_top->next;
        delete m_top;
        m_top = next;
    }
}

void IntegerStack::Push(int value)
{
    Node* newNode = new Node();

    newNode->value = value;
    newNode->next = m_top;
    m_top = newNode;
}

int IntegerStack::Pop()
{
    int value = m_top->value;
    Node* nextNode = m_top->next;
    delete m_top;
    m_top = nextNode;

    return value;

    // m_stack[--top] == top = top - 1; m_stack[top];
    // m_stack[top--] == m_stack[top]; top = top -1;
}
