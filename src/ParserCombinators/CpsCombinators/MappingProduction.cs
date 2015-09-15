﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpsCombinators
{
    public class MappingProduction<T, TR> : ProductionBase<TR>
    {
        private ProductionBase<T> m_p;
        private Func<T, TR> m_resultSelector;

        public MappingProduction(ProductionBase<T> p, Func<T, TR> resultSelector)
        {
            m_p = p;
            m_resultSelector = resultSelector;
        }

        public override Parse<TFuture> BuildParse<TFuture>(Future<TR, TFuture> future)
        {
            return scanner =>
                m_p.BuildParse(value => future(m_resultSelector(value)))(scanner);
        }
    }
}
