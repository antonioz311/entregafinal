using GestionInventario.Models;
using GestionInventario.Repositories;
using System;

namespace GestionInventario.Services
{
    public class MovimientoServicio
    {
        private readonly MovimientoRepositorio _movimientoRepositorio;

        public MovimientoServicio(MovimientoRepositorio movimientoRepositorio)
        {
            _movimientoRepositorio = movimientoRepositorio;
        }

        public void AdicionarExistencias(int productoId, int cantidad, string motivo)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a 0");

            var movimiento = new Movimiento
            {
                ProductoId = productoId,
                Cantidad = cantidad,
                Tipo = "Entrada",
                Motivo = motivo,
                Fecha = DateTime.UtcNow
            };

            _movimientoRepositorio.CrearMovimiento(movimiento);
        }

        public void DisminuirExistencias(int productoId, int cantidad, string motivo)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a 0");

            var movimiento = new Movimiento
            {
                ProductoId = productoId,
                Cantidad = -cantidad,
                Tipo = "Salida",
                Motivo = motivo,
                Fecha = DateTime.UtcNow
            };

            _movimientoRepositorio.CrearMovimiento(movimiento);
        }

        public object ObtenerMovimientos()
        {
            return _movimientoRepositorio.ObtenerMovimientos();
        }
    }
}
