<template>
    
    <div class="fixed top-0 z-10 flex items-center justify-center w-full gap-4 pt-2 mt-20 theme-bg-primary content-padding">
        <horizontal-scroll :scrollChangeSource="listingCategories" class="relative">
            <listing-category-card v-for="listingCategory in listingCategories"
                :listingCategory="listingCategory"
                :selectedCategoryId="selectedCategoryId"
                :index="listingCategory.id"
                @onCategorySelected="onCategorySelected"/>
        </horizontal-scroll>

        <!-- Filters actions -->
        <div class="w-[500px] hidden lg:flex items-center justify-center pb-3">
            <listings-filter :isMobile="false"/>   
            
            <button class="flex items-center justify-center w-auto h-12 gap-3 px-4 ml-3 rounded-lg group theme-border theme-text-primary">
                <span class="text-xs font-medium whitespace-nowrap">Display total before taxes</span>
                
                <switch-button/>
            </button>   
        </div>
    </div>

</template>

<script setup lang="ts">

import { ListingCategory } from "@/modules/locations/models/ListingCategory";
import HorizontalScroll from "@/common/components/HorizontalScroll.vue";
import ListingCategoryCard from "@/modules/locations/components/ListingCategoryCard.vue";
import ListingsFilter from "@/modules/locations/components/ListingsFilter.vue";
import SwitchButton from "@/common/components/SwitchButton.vue";

const props = defineProps({
    listingCategories: {
        type: Array<ListingCategory>,
        required: true
    },
    selectedCategoryId: {
        type: String,
        required: true
    }
});

const emit = defineEmits({
    onCategorySelected: (categoryId: string) => true
});

const onCategorySelected = (categoryId: string) => {
    emit("onCategorySelected", categoryId);
}

</script>