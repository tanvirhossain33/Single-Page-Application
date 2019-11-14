/// <reference path="PoDescription.cs.d.ts" />

declare module server {
	interface Po extends Entity {
		companyId: string;
		buyerId: string;
		poNo: string;
		orderDate: Date;
		shipStartDate: Date;
		cancelDate: Date;
		paymentTerms: string;
		packingMethod: string;
		shipMethod: string;
		shipTerms: string;
		shipTo: string;
		shipAddress: string;
		salesPerson: string;
		subtotal: number;
		salesTax: number;
		total: number;
		status: any;
		company: {
			name: string;
			address1: string;
			address2: string;
			contactPerson: string;
			phone: string;
			warehouseName: string;
			warehouseAddress: string;
			city: string;
			ppoSign: string;
			invoiceSign: string;
			state: string;
			zip: string;
			country: string;
			email: string;
			fax: string;
		};
		buyer: {
			name: string;
			address: string;
			city: string;
			billTo: string;
			billAddress: string;
			shipTo: string;
			shipAddress: string;
			state: string;
			zip: string;
			country: string;
			shipCity: string;
			shipState: string;
			shipZip: string;
			shipCountry: string;
		};
		poDescriptions: server.PoDescription[];
	}
	interface Entity {
		id: string;
		created: Date;
		createdBy: string;
		modified: Date;
		modifiedBy: string;
	}
}
