﻿namespace Homeo.DAL.Interfaces {
    public interface IUnitOfWork {
        void Commit();
        void Rollback();
    }
}
