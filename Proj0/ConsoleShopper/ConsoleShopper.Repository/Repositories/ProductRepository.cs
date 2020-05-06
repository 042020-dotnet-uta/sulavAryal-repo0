﻿using ConsoleShopper.Domain;
using ConsoleShopper.Repository.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleShopper.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ConsoleShopperDbContext _dbContext;

        public ProductRepository(ConsoleShopperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Product Inventory by Id
        /// <summary>
        /// Returns Inventory by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<InventoryItem> GetProductByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Inventory
               .Include(i => i.Product)
               .Include(i => i.Store)
               .AsNoTracking()
               .FirstOrDefaultAsync(i => i.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //_logger.LogInformation("Couldn't reterive data from database");
                return null;
            }
        }
        #endregion

        #region Products by Store
        public async Task<IEnumerable<InventoryItem>> GetProductsByStoreAsync(int storeId)
        {
            try
            {
                return await _dbContext.Inventory
                    .Include(i => i.Product)
                    .Include(i => i.Store)
                    .Where(i => i.Store.Id == storeId)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

        #region Product by Code
        public async Task<InventoryItem> GetProductByCodeAsync(string code)
        {
            try
            {
                return await _dbContext.Inventory
               .Include(i => i.Product)
               .Include(i => i.Store)
               .AsNoTracking()
               .FirstOrDefaultAsync(i => i.Product.ProductCode == code);
            }
            catch (Exception)
            {

                Console.WriteLine("Database returned no result ");
                return null;
            }

        }
        #endregion

        //public async Task<InventoryItem> GetProductByCodeAsync(int id)
        //{
        //    try
        //    {
        //        var result = await _dbContext.Inventory
        //       .Include(i => i.Product)
        //       .Include(i => i.Store)
        //       .AsNoTracking()
        //       .FirstOrDefaultAsync(i => i.Id == id);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        //_logger.LogInformation("Couldn't reterive data from database");
        //        return null;
        //    }
        //}

        #region Get All product Inventory
        public async Task<IEnumerable<InventoryItem>> GetAllInventoryAsync()
        {
            try
            {
                return await _dbContext.Inventory
                              .Include(i => i.Product)
                              .Include(i => i.Store)
                              .AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                //_logger.LogInformation("Couldn't read from database");
                return null;
            }
        }
        #endregion

        #region Get Product Inventory by Search Term
        public async Task<IEnumerable<InventoryItem>> GetProductsBySearchStringAsync(string searchString)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    var result = await _dbContext.Inventory
                        .Include(i => i.Product)
                        .Include(i => i.Store)
                        .AsNoTracking()
                        .Where(x => x.Product.Name.ToLower().Contains(searchString.ToLower())).ToListAsync();
                    return result;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

        #region Create a Product and Populate Product Inventory
        public async Task CreateProductAsync(InventoryItem inventoryItemToCreate)
        {
            try
            {
                try
                {
                    _dbContext.Inventory.Add(inventoryItemToCreate);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Update Product Inventory
        public async Task UpdateProductAsync(InventoryItem inventoryItemToUpdate)
        {
            try
            {
                _dbContext.Inventory.Update(inventoryItemToUpdate);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Delete Product Inventory
        public async Task DeleteProductAsync(int id)
        {
            var productToDelete = await _dbContext.Inventory
                  .Include(i => i.Product)
                  .Include(i => i.Store)
                  .AsNoTracking()
                  .FirstOrDefaultAsync(x => x.Id == id);
            try
            {
                _dbContext.Inventory.Remove(productToDelete);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Get All Products
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                var result = await _dbContext.Products.AsNoTracking().ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
          
        }
        #endregion
    }
}
