package com.dell.vendingmachine.service.impl;

import com.dell.vendingmachine.dto.VendingCredit;
import com.dell.vendingmachine.model.Product;
import com.dell.vendingmachine.model.VendingMachine;
import com.dell.vendingmachine.repository.VendingMachineRepository;
import com.dell.vendingmachine.service.VendingMachineService;
import lombok.val;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
public class VendingMachineImpl implements VendingMachineService {

    final
    VendingMachineRepository vendingMachineRepository;

    public VendingMachineImpl(VendingMachineRepository vendingMachineRepository) {
        this.vendingMachineRepository = vendingMachineRepository;
    }

    @Override
    public VendingMachine AddCredit(Long id, double credit){

        VendingMachine v =  vendingMachineRepository.getById( id);
        v.setCredit(v.getCredit() + credit);

        return vendingMachineRepository.save(v);
    }

    @Override
    public Product BuyProduct(long id, long productId) {
        VendingMachine vm = vendingMachineRepository.getById(id);

        vendingMachineRepository.save(vm);

        return vm.getProducts().stream().filter(p -> p.getProductId() == productId).findFirst().get();
    }
}
