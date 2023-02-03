namespace DataStructure;

public sealed record Node<Any>(Any Data, Node<Any>? Next = null);