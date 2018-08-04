import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarrinhoDeCompraComponent } from './carrinho-de-compra.component';

describe('CarrinhoDeCompraComponent', () => {
  let component: CarrinhoDeCompraComponent;
  let fixture: ComponentFixture<CarrinhoDeCompraComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarrinhoDeCompraComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarrinhoDeCompraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
