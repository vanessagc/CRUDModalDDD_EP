using System;
using EP.CrudModalDDD.Domain.DTO;
using EP.CrudModalDDD.Domain.Entities;
using EP.CrudModalDDD.Domain.Interfaces.Repository;
using EP.CrudModalDDD.Domain.Interfaces.Service;
using EP.CrudModalDDD.Domain.Validations.Clientes;

namespace EP.CrudModalDDD.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ClienteService(IClienteRepository clienteRepository, IEnderecoRepository enderecoRepository)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if(!cliente.IsValid())
            {
                return cliente;
            }

            cliente.ValidationResult = new ClienteAptoParaCadastroValidation(_clienteRepository).Validate(cliente);
            if (!cliente.ValidationResult.IsValid)
            {
                return cliente;
            }

            cliente.ValidationResult.Message = "Cliente cadastrado com sucesso :)";
            return _clienteRepository.Adicionar(cliente);
        }

        public Cliente ObterPorId(Guid id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return _clienteRepository.ObterPorCpf(cpf);
        }

        public Cliente ObterPorEmail(string email)
        {
            return _clienteRepository.ObterPorEmail(email);
        }

        public Paged<Cliente> ObterTodos(string nome, int pageSize, int pageNumber)
        {
            return _clienteRepository.ObterTodos(nome, pageSize, pageNumber);
        }

        public Cliente Atualizar(Cliente cliente)
        {
            return _clienteRepository.Atualizar(cliente);
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }

        public Endereco AdicionarEndereco(Endereco endereco)
        {
            return _enderecoRepository.Adicionar(endereco);
        }

        public Endereco AtualizarEndereco(Endereco endereco)
        {
            return _enderecoRepository.Atualizar(endereco);
        }

        public Endereco ObterEnderecoPorId(Guid id)
        {
            return _enderecoRepository.ObterPorId(id);
        }

        public void RemoverEndereco(Guid id)
        {
            _enderecoRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}