namespace DefaultNamespace.Interfaces;

public interface IDocumentStore
{
    IDisposable OpenSession();
}