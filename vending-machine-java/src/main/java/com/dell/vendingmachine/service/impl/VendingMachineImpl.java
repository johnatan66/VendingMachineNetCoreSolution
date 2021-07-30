package com.dell.vendingmachine.service.impl;

import com.dell.vendingmachine.dto.VendingCredit;
import com.dell.vendingmachine.model.VendingMachine;
import com.dell.vendingmachine.repository.VendingMachineRepository;
import com.dell.vendingmachine.service.VendingMachineService;
import lombok.val;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
public class VendingMachineImpl implements VendingMachineService {

    @Autowired
    VendingMachineRepository vendingMachineRepository;


    @Override
    public VendingMachine AddCredit(Long id, VendingCredit credit){

        VendingMachine v =  vendingMachineRepository.getById( id);
        v.setCredit(v.getCredit() + credit.Credit);

        return vendingMachineRepository.save(v);
    }

    @Transactional
    public VendingMachine Create(VendingMachine vendingMachine){

        return vendingMachineRepository.save(vendingMachine);

    }

    @Override
    public  VendingMachine FindById(long id){

        return  vendingMachineRepository.findById(id).get();
    }
}
