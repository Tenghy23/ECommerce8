﻿global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
global using Domain.AggregatesModel.CartAggregate;
global using Domain.AggregatesModel.CategoryAggregate;
global using Domain.AggregatesModel.DiscountAggregate;
global using Domain.AggregatesModel.InventoryAggregate;
global using Domain.AggregatesModel.OrderAggregate;
global using Domain.AggregatesModel.IDiscountRepository;
global using Domain.AggregatesModel.OrderDetailsAggregate;
global using Domain.AggregatesModel.PaymentDetailsAggregate;
global using Domain.AggregatesModel.ProductAggregate;
global using Domain.AggregatesModel.UserAggregate;
global using Domain.AggregatesModel.AddressAggregate;
global using Domain.AggregatesModel.CommonAggregate;
global using RandomDataGenerator.FieldOptions;
global using RandomDataGenerator.Randomizers;
global using Microsoft.EntityFrameworkCore;
global using System.Reflection;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Domain.Exceptions;
global using Domain.Utilities;
global using System.Diagnostics;
global using System.Runtime.Serialization;
global using System.Runtime.CompilerServices;
global using Microsoft.AspNetCore.Identity;