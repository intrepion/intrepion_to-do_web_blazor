﻿using Intrepion.ToDo.BusinessLogic.Entities.Dtos.Admin;

namespace Intrepion.ToDo.BusinessLogic.Entities.ViewModels.Admin;

public class ApplicationRoleAdminEditViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public static ApplicationRoleAdminEditViewModel FromApplicationRoleAdminDto(ApplicationRoleAdminDto? applicationRoleAdminDto)
    {
        if (applicationRoleAdminDto == null)
        {
            return new ApplicationRoleAdminEditViewModel();
        }

        return new ApplicationRoleAdminEditViewModel
        {
            Id = applicationRoleAdminDto.Id,
            Name = applicationRoleAdminDto.Name,
        };
    }

    public static ApplicationRoleAdminDto ToApplicationRoleAdminDto(ApplicationRoleAdminEditViewModel? applicationRoleAdminEditViewModel)
    {
        if (applicationRoleAdminEditViewModel == null)
        {
            return new ApplicationRoleAdminDto();
        }

        return new ApplicationRoleAdminDto
        {
            Id = applicationRoleAdminEditViewModel.Id,
            Name = applicationRoleAdminEditViewModel.Name,
        };
    }
}
