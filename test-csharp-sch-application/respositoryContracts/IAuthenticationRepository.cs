﻿using test_csharp_sch_domain.entities;

namespace test_csharp_sch_application.respositoryContracts
{
    public interface IAuthenticationRepository
    {
        bool AreRegistered(Credentials credentials);
    }
}
