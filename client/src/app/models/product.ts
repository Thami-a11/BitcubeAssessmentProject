export interface Product {
    id:       number;
    products: ProductElement[];
}

export interface ProductElement {
    id:            number;
    item:          string;
    productType:   string;
    numItems:      number;
    productPrices: null;
    itemSummaries: null;
}