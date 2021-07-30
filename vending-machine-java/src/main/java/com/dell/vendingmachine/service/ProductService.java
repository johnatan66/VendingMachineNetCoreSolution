package com.dell.vendingmachine.service;

import com.dell.vendingmachine.dto.VendingCredit;
import com.dell.vendingmachine.model.Product;
import com.dell.vendingmachine.model.VendingMachine;
import org.springframework.stereotype.Service;


@Service
public interface ProductService {

    public Product Create(Product product);

}
