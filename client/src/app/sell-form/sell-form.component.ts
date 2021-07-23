import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Product, ProductElement } from '../models/product';
import { StoreService } from '../_services/store.service';

@Component({
  selector: 'app-sell-form',
  templateUrl: './sell-form.component.html',
  styleUrls: ['./sell-form.component.sass']
})
export class SellFormComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  SellForm: FormGroup;

  products: Product;

  constructor(private formBuilder: FormBuilder, private storeService: StoreService, private router: Router) { }


  ngOnInit(): void {
    this.initializeForm();
    this.storeService.SummaryOfAll().subscribe(summary => {
      this.products = summary;
    });
  }

  initializeForm() {

    this.SellForm = this.formBuilder.group({
      item: ['', Validators.required],
      numItems: ['', Validators.required]
    });
  }

  submit() {

    this.storeService.SellProducts(this.SellForm.value).subscribe(() => {
      console.log(this.SellForm.value);
      this.router.navigateByUrl('Summary');
    }, error => {
      console.log(error)
    });

  }

  cancel() {
    this.cancelRegister.emit(false);
    this.router.navigateByUrl('Add');
  }

}