/// <reference path="Po.cs.d.ts" />

declare module server {
	interface PoDescription extends Entity {
		poId: string;
		description: string;
		style: string;
		color: string;
		label: string;
		size: string;
		cartons: number;
		quantity: number;
		unitPrice: number;
		lineTotal: number;
		wt: number;
		po: server.Po;
	}
	interface Entity {
		id: string;
		created: Date;
		createdBy: string;
		modified: Date;
		modifiedBy: string;
	}
}
