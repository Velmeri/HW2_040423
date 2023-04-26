using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_040423
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IBuilding[] buildings = new IBuilding[]
		{
			new Residence(),
			new Factory(),
			new Bank()
		};

			InsuranceVisitor visitor = new InsuranceVisitor();

			foreach (IBuilding building in buildings) {
				building.Accept(visitor);
			}

			Console.ReadKey(true);
		}

		interface IBuilding
		{
			void Accept(IVisitor visitor);
		}

		class Residence : IBuilding
		{
			public void Accept(IVisitor visitor)
			{
				visitor.VisitResidence(this);
			}

			public void OfferMedicalInsurance()
			{
				Console.WriteLine("Offering medical insurance to the resident.");
			}
		}

		class Factory : IBuilding
		{
			public void Accept(IVisitor visitor)
			{
				visitor.VisitFactory(this);
			}

			public void OfferFireInsurance()
			{
				Console.WriteLine("Offering fire insurance to the factory owner.");
			}
		}

		class Bank : IBuilding
		{
			public void Accept(IVisitor visitor)
			{
				visitor.VisitBank(this);
			}

			public void OfferRobberyInsurance()
			{
				Console.WriteLine("Offering robbery insurance to the bank customer.");
			}
		}

		interface IVisitor
		{
			void VisitResidence(Residence residence);
			void VisitFactory(Factory factory);
			void VisitBank(Bank bank);
		}
		class InsuranceVisitor : IVisitor
		{
			public void VisitResidence(Residence residence)
			{
				residence.OfferMedicalInsurance();
			}

			public void VisitFactory(Factory factory)
			{
				factory.OfferFireInsurance();
			}

			public void VisitBank(Bank bank)
			{
				bank.OfferRobberyInsurance();
			}
		}
	}
}
