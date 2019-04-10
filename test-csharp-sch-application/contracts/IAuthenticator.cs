﻿using test_csharp_sch_domain.entities;

namespace test_csharp_sch_application.contracts
{
    public interface IAuthenticator
    {
        bool AreRegistered(Credentials credentials);
    }
}
