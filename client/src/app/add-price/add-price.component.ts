import { AfterContentInit, Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Product, ProductElement } from '../models/product';
import { StoreService } from '../_services/store.service';

@Component({
  selector: 'app-add-price',
  templateUrl: './add-price.component.html',
  styleUrls: ['./add-price.component.sass']
})
export class AddPriceComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  PriceForm: FormGroup;

  products: Product;
  numItems: ProductElement[];

  constructor(private formBuilder: FormBuilder, private storeService: StoreService, private router: Router) { }


  ngOnInit(): void {
    this.initializeForm();
    this.storeService.SummaryOfAll().subscribe(summary => {
      this.products = summary;
    });
  }

  initializeForm() {

    this.PriceForm = this.formBuilder.group({
      price: ['', Validators.required],
      productPurchaseOrderId: ['', Validators.required]
    });
  }

  submit() {

    this.storeService.AddToPrice(this.PriceForm.value).subscribe(() => {
      console.log(this.PriceForm.value);
      this.router.navigateByUrl('Summary');
    }, error => {
      console.log(error.error)
    });

  }

  cancel() {
    this.cancelRegister.emit(false);
    this.router.navigateByUrl('Add');
  }

}
