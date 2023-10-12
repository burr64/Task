using Task.BLL.DTO;
using Task.BLL.Interfaces;

using Task.DAL.Entities;
using Task.DAL.Interfaces;

namespace Task.BLL.Services
{
    public class OrderService : IEntityService<OrdersDto>
    {
        private readonly IRepository<Orders> _orderRepository;

        public OrderService(IRepository<Orders> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<OrdersDto> GetAll()
        {
            var orders = _orderRepository.GetAll()
                .Select(order => new OrdersDto
                {
                    Id = order.Id,
                    UserId = order.UserId,
                    Price = order.Price
                })
                .ToList();

            return orders;
        }

        public OrdersDto GetById(int id)
        {
            var order = _orderRepository.Get(id);

            var orderDto = new OrdersDto
            {
                Id = order.Id,
                UserId = order.UserId,
                Price = order.Price
            };

            return orderDto;
        }

        public void Create(OrdersDto orderDto)
        {
            var order = new Orders
            {
                UserId = orderDto.UserId,
                Price = orderDto.Price
            };

            _orderRepository.Create(order);
        }

        public void Update(OrdersDto orderDto)
        {
            var order = _orderRepository.Get(orderDto.Id);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found");
            }

            order.UserId = orderDto.UserId;
            order.Price = orderDto.Price;

            _orderRepository.Update(order);
        }

        public void Delete(int id)
        {
            var order = _orderRepository.Get(id);

            _orderRepository.Delete(id);
        }
    }
}
