/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { BeboerComponent } from './beboer.component';

let component: BeboerComponent;
let fixture: ComponentFixture<BeboerComponent>;

describe('beboer component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ BeboerComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(BeboerComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});