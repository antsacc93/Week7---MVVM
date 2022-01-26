using Avanade.Allocation.Core.BusinessLayer;
using Avanade.Allocation.Core.Mock.Repositories;
using Avanade.Allocation.Core.Mock.Storage;
using Avanade.Allocation.Core.Repositories;
using System;
using Xunit;

namespace Avanade.Allocation.WPF.Test
{
    public class AuthenticationTest
    {
        [Fact]
        public void ShouldSignInOkCredential()
        {
            //ARRANGE
            //Recupero i dati che mi serviranno per gestire l'operazione
            AllocationMockStorage.Initialize();

            //Creazione del repository
            IUserRepository userRepository = new UserRepositoryMock();

            //Creazione del business layer
            AuthenticationBusinessLayer layer = new AuthenticationBusinessLayer(userRepository);

            var userName = "mario.rossi";
            var password = "12345";

            //ACT - Eseguo l'operazione da testare
            var result = layer.SignIn(userName, password);

            //ASSERT - Verifica del risultato ottenuto
            Assert.True(result.Success);
        }

        [Fact]
        public void ShouldSignInNotOkCredential()
        {
            //ARRANGE
            //Recupero i dati che mi serviranno per gestire l'operazione
            AllocationMockStorage.Initialize();

            //Creazione del repository
            IUserRepository userRepository = new UserRepositoryMock();

            //Creazione del business layer
            AuthenticationBusinessLayer layer = new AuthenticationBusinessLayer(userRepository);

            var userName = "mario.rossi";
            var password = "123456";

            //ACT - Eseguo l'operazione da testare
            var result = layer.SignIn(userName, password);

            //ASSERT - Verifica del risultato ottenuto
            Assert.False(result.Success);
        }
    }
}
