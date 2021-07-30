package com.dell.vendingmachine.controllers;

import com.dell.vendingmachine.dto.VendingCredit;
import com.dell.vendingmachine.model.Product;
import com.dell.vendingmachine.model.VendingMachine;
import com.dell.vendingmachine.service.ProductService;
import com.dell.vendingmachine.service.VendingMachineService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;


@RestController
@RequestMapping("/product")
public class ProductController {

    @Autowired
    ProductService productService;

    public ProductController(){}

    @GetMapping(value="hello")
    public ResponseEntity<String> hello() {
        return new ResponseEntity<String>("Hello." , HttpStatus.OK);
    }


    @PostMapping(value="create")
    public ResponseEntity<Product> Create(@RequestBody Product product ) {

        Product created = productService.Create(product);
        return new ResponseEntity<Product>(created, HttpStatus.OK);
    }
}
