﻿namespace Backend_Project.Domain.Exceptions.EntityExceptions;

public class DuplicateEntityException<T> : EntityException<T>
{
    public DuplicateEntityException()
    {
    }

    public DuplicateEntityException(string message) : base(message)
    {
    }
}