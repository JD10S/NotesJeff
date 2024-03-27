﻿    using DAL;
    using Entity;

namespace BLL
{
    public class UserServices
    {
        private readonly NoteDBContext noteDBContext;

        public UserServices(NoteDBContext noteDBContext)
        {
            this.noteDBContext = noteDBContext;
        }

        public string AddUser(User user)
        {
            try
            {
                noteDBContext.Add(user);
                noteDBContext.SaveChanges();
                return $"{user.UserName} fue registrado correctamente";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                var users = noteDBContext.Users.ToList();
                return users;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string UpdateUser(User user)
        {
            try
            {
                noteDBContext.Update(user);
                noteDBContext.SaveChanges();
                return $"{user.UserName} fue Modificado correctamente";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string DeleteUser(int id)
        {
            try
            {
                var user = noteDBContext.Users.FirstOrDefault(x => x.Id == id);
                noteDBContext.Remove(user);
                noteDBContext.SaveChanges();
                return $"{user.UserName} fue Eliminado correctamente";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
