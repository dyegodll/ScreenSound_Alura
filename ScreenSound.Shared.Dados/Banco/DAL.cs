namespace ScreenSound.Banco
{
    public class DAL<T> where T: class
    {
        private readonly ScreenSoundContext _context;

        public DAL(ScreenSoundContext context)
        {
            _context = context;
        }

        public IEnumerable<T> Listar()
        {
            var lista = _context.Set<T>().ToList();
            lista.ForEach(obj => Console.WriteLine(obj));
            return lista;
        }

        public IEnumerable<T> ListarPor(Func<T, bool> condicao)
        {
            return _context.Set<T>().Where(condicao);
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
            var obj = _context.Set<T>().FirstOrDefault(condicao);
            Console.WriteLine(obj);
            return obj;
        }

    }
}
