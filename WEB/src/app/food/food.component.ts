import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FoodParams } from '../shared/models/foodParams';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productTypes';
import { FoodService } from './food.service';

@Component({
  selector: 'app-food',
  templateUrl: './food.component.html',
  styleUrls: ['./food.component.scss']
})
export class FoodComponent implements OnInit {
  @ViewChild('search', {static: true}) searchTerm: ElementRef | undefined;
  products: IProduct[] = [];
  types: IType[] = [];
  foodParams = new FoodParams();
  totalCount: number = 0;
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'}
  ];

  constructor(private foodService: FoodService) { }

  ngOnInit() {
    this.getProducts();
    this.getTypes();
  }

  getProducts(){
    this.foodService.getProducts(this.foodParams).subscribe(response => {
      if (!response) { this.products = []; return; }
      this.products = response.data;
      this.foodParams.pageNumber = response.pageIndex;
      this.foodParams.pageSize = response.pageSize;
      this.totalCount = response.count;

    }, error => {
      console.log(error);
    })
  }

  getTypes() {
    this.foodService.getTypes().subscribe(response => {
      this.types = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log(error);
    });
  }

  onTypeSelected(typeId: number){
    this.foodParams.typeId = typeId;
    this.foodParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(event: any)
  {
    this.foodParams.sort = event.target.value;
    this.getProducts();
  }

  onPageChanged(event: any) {
    if(this.foodParams.pageNumber !== event)
    {
      this.foodParams.pageNumber = event;
      this.getProducts();
    }
  }

  onSearch(): void {
    if (!this.searchTerm) { return ; }
    this.foodParams.search = this.searchTerm.nativeElement.value;
    this.foodParams.pageNumber = 1;
    this.getProducts();
  }

  onReset()
  {
    if (!this.searchTerm) { return ; }
    this.searchTerm.nativeElement.value = '';
    this.foodParams = new FoodParams();
    this.getProducts();
  }
}
