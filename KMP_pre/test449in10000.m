V_sch_len=test449in10000(:,1);
BF449=test449in10000(:,2);
KMP449=test449in10000(:,3);
figure;
plot(V_sch_len,test449in10000(:,2),'LineWidth',2);
hold on
xlabel('Length of Search String /char');
ylabel('Duration /ms');
plot(V_sch_len,test449in10000(:,3),'LineWidth',2);
legend('BF','KMP','Location','NorthWest');
title('length of main string=10000,n=5')
hold off