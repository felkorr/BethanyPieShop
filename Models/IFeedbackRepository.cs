﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public interface IFeedbackRepository
    {

        void AddFeedback(Feedback feedback);//metodo para adicionar um feedback

    }
}
