namespace ScreenSound.Banco
{
    internal class DAL<T> where T: class
    {
        protected readonly ScreenSoundContext _context;

        protected DAL(ScreenSoundContext context)
        {
            _context = context;
        }

        public IEnumerable<T> Listar()
        {
            var lista = _context.Set<T>().ToList();
            lista.ForEach(a => Console.WriteLine(a + "\n"));
            return lista;
        }

        public void Adicionar(T objeto)
        {
            _context.Set<T>().Add(objeto);
            _context.SaveChanges();
            Console.WriteLine($"{objeto} adicionado com sucesso!\n");
        }

        public void Atualizar(T objeto)
        {
            _context.Set<T>().Update(objeto);
            _context.SaveChanges();
            Console.WriteLine($"{objeto} atualizado com sucesso!\n");
        }

        public void Deletar(T objeto)
        {
            _context.Set<T>().Remove(objeto);
            _context.SaveChanges();
            Console.WriteLine($"{objeto} removido com sucesso!\n");
        }

        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return _context.Set<T>().FirstOrDefault(condicao);
        }

    }
}
