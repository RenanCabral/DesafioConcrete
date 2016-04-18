# DesafioConcrete
Desafio de C# - Concrete Solutions

Recursos: 

http://desafioconrete.apphb.com/api/signup

http://desafioconrete.apphb.com/api/login

http://desafioconrete.apphb.com/api/profile/id

Segue o modelo de objetos para cada requisição: 

Signup: 

POST
{
    nome : "Teste",
    email: "teste@mail.com",
    senha: "123456",
    telefones: [{CodigoArea: "021", Numero: "111222333"},{CodigoArea: "021", Numero: "222333444"}]
}

Login: 

POST
{
    email:"renan@mail.com",
    senha:"123456"
}

Profile: 

GET

Header na request: Authorization - Bearer {token}