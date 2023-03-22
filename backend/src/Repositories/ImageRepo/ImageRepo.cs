namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;

public class ImageRepo : CrudRepo<Image, ImageDTO>, IImageRepo
{
  public ImageRepo(AppDbContext dbContext) : base(dbContext)
  {
  }
}