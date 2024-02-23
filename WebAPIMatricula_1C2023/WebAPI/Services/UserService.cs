using WebAPI.Entities;
using WebAPI.Helpers;

namespace WebAPI.Services
{
    public interface IUserService
    {
        Usuario Authenticate(string username, string password);
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        Usuario Create(Usuario user, string password);
        void Update(Usuario user, string password = null);
        void Delete(int id);
    }
    public class UserService : IUserService
    {
        private DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public Usuario Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Usuario.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuario;
        }

        public Usuario GetById(int id)
        {
            return _context.Usuario.Find(id);
        }

        public Usuario Create(Usuario user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password requerido");

            if (_context.Usuario.Any(x => x.Username == user.Username))
                throw new AppException("Nombre de usuario \"" + user.Username + "\" ya existe");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Usuario.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Update(Usuario userParam, string password = null)
        {
            var user = _context.Usuario.Find(userParam.Codigo);

            if (user == null)
                throw new AppException("Usuario no encontrado");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            {
                // throw error if the new username is already taken
                if (_context.Usuario.Any(x => x.Username == userParam.Username))
                    throw new AppException("Nombre de usuario " + userParam.Username + " ya existe");

                user.Username = userParam.Username;
            }

            // update user properties if provided
            //NOMBRE E IDENTIFICACION NO ACTUALIZABLES
            //if (!string.IsNullOrWhiteSpace(userParam.Identificacion))
            //    user.Identificacion = userParam.Identificacion;

            //if (!string.IsNullOrWhiteSpace(userParam.NombreCompleto))
            //    user.NombreCompleto = userParam.NombreCompleto;


            if (!string.IsNullOrWhiteSpace(userParam.CorreoElectronico))
                user.CorreoElectronico = userParam.CorreoElectronico;


            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Usuario.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Usuario.Find(id);
            if (user != null)
            {
                _context.Usuario.Remove(user);
                _context.SaveChanges();
            }
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("El password no puede ser una cadena vacía o espacios en blanco.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("El password no puede ser una cadena vacía o espacios en blanco.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Longitud invalida del password hash (64 bytes esperados).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Longitud invalida del password salt (128 bytes esperados).", "passwordSalt");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
